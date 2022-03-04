﻿using System;
using System.Linq;
using System.Collections.Generic;
namespace SudokuLibrary
{
    public class SudokuSolver
    {
        public char[][] sudokuArrays;
        Dictionary<string, int[]> arrayLinker;
        Dictionary<string, string> notes;
        bool valueAdded;
        static void ArgumentValidator(char[][] board)
        {
            if (board.GetLength(0) != 9)
                throw new ArgumentException("Input must be jagged array of 9 character arrays with lengths of 9.");
            var values = new char[10] { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < 9; i++)
            {
                if (board[i].Length != 9)
                    throw new ArgumentException("Input must be jagged array of 9 character arrays with lengths of 9.");
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (!values.Contains(board[i][j]))
                        throw new ArgumentException("Each array element must be a number between 1-9 or ' '.");
                }
            }
        }
        void InitializeFields()
        {
            valueAdded = true;
            sudokuArrays = new char[27][];
            arrayLinker = new Dictionary<string, int[]>();
            notes = new Dictionary<string, string>();
            for (int i = 0; i < 27; i++)
                sudokuArrays[i] = new char[9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var blockNum = 18 + (i / 3) * 3 + j / 3;
                    var blockPos = (i % 3) * 3 + j % 3;
                    var iStr = i.ToString();
                    var jStr = j.ToString();
                    arrayLinker.Add
                        (iStr + jStr, new int[4] { j + 9, i, blockNum, blockPos });
                    arrayLinker.Add
                        ((j + 9).ToString() + iStr, new int[4] { i, j, blockNum, blockPos });
                    arrayLinker.Add
                        (blockNum.ToString() + blockPos.ToString(), new int[4] { i, j, j + 9, i });
                    notes.Add(iStr + jStr, "123456789");
                }
            }
        }
        void InputBoard(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(board[i][j] != ' ')
                    {
                        AddNum(board[i][j], i, j);
                    }
                }
            }
        }
        void AddNum(char num, int row, int col)
        {
            var coPositions = arrayLinker[row.ToString() + col.ToString()];
            sudokuArrays[row][col] = num;
            sudokuArrays[coPositions[0]][coPositions[1]] = num;
            sudokuArrays[coPositions[2]][coPositions[3]] = num;
            notes.Remove(row.ToString() + col.ToString());
            EditNotes(num, row);
            EditNotes(num, col + 9);
            EditNotes(num, coPositions[2]);
            BoardValidator(sudokuArrays);
        }
        void EditNotes(char num, int sudokuArray, string[] exceptions = null)
        {
            var row = 0;
            var col = 0;
            var str = "";
            for (int i = 0; i < 9; i++)
            {
                
                var coPosistions = arrayLinker[sudokuArray.ToString() + i.ToString()];
                if (sudokuArray < 9)
                {
                    row = sudokuArray;
                    col = i;
                    str = row.ToString() + col.ToString();
                }
                else
                {
                    row = coPosistions[0];
                    col = coPosistions[1];
                    str = row.ToString() + col.ToString();
                }
                if (exceptions != null && exceptions.Contains(str))
                    continue;
                else if (notes.ContainsKey(str) && notes[str].Contains(num))
                {
                    var note = notes[str];
                    var index = note.IndexOf(num);
                    note = note.Remove(index, 1);
                    if (note.Length == 1)
                    {
                        AddNum(note[0], row, col);
                        valueAdded = true;
                    }
                    else
                    {
                        notes[str] = note;
                        valueAdded = true;
                    }
                }
            }
        }
        public static void BoardValidator(char[][] sudokuArrays)
        {
            for (int i = 0; i < 27; i++)
            {
                var currentArray = new char[9];
                for (int j = 0; j < 9; j++)
                {
                    if (sudokuArrays[i][j] != '\0' && currentArray.Contains(sudokuArrays[i][j]))
                        throw new ArgumentException("This is not a valid sudoku board.");
                    currentArray[j] = sudokuArrays[i][j];
                }
            }
        }
        void ScanByNumber(char num)
        {
            var array = 0;
            for (int i = 18; i < 27; i++)
            {   //for some reason 7 is causing errors
                var block = sudokuArrays[i];
                if (block.Contains(num))
                    continue;
                var openSpots = new string[9];
                var count = 0;
                string[] exceptions;
                for (int j = 0; j < 9; j++)
                {
                    var str = i.ToString() + j.ToString();
                    var coPositions = arrayLinker[str];
                    if (block[j] == '\0' && !sudokuArrays[coPositions[0]].Contains(num) && !sudokuArrays[coPositions[2]].Contains(num))
                    {
                        openSpots[count] = str;
                        count++;
                    }
                }
                if (count == 1)
                {
                    var coPositions = arrayLinker[openSpots[0]];
                    AddNum(num, coPositions[0], coPositions[1]);
                    valueAdded = true;
                }
                else if (count == 3 || count == 2)
                {
                    var row= arrayLinker[openSpots[0]][0];
                    var col = arrayLinker[openSpots[0]][1];
                    if ((count == 2 && arrayLinker[openSpots[1]][0] == row) ||
                        (count == 3 && arrayLinker[openSpots[1]][0] == row && arrayLinker[openSpots[2]][0] == row))
                        array = row;
                    else if ((count == 2 && arrayLinker[openSpots[1]][1] == col) ||
                        (count == 3 && arrayLinker[openSpots[1]][1] == col && arrayLinker[openSpots[2]][1] == col))
                        array = col + 9;
                    else
                        continue;
                    exceptions = new string[count];
                    for (int j = 0; j < count; j++)
                    {
                        var coPositions = arrayLinker[openSpots[j]];
                        exceptions[j] = coPositions[0].ToString() + coPositions[1].ToString();
                    }
                    EditNotes(num, array, exceptions);
                }
            }
        }
        public void SudokuSolverSolution(char[][] board)
        {
            ArgumentValidator(board);
            InitializeFields();
            InputBoard(board);
            BoardValidator(sudokuArrays);
            while (valueAdded == true)
            {
                valueAdded = false;
                for (int i = 1; i < 10; i++)
                {
                    ScanByNumber(Convert.ToChar(i + '0'));
                }
            }
        }
        //Augment ScanByNumers so that it can eliminate open spots based on deduction.
        //Only need to add program to make this gitpod ready.
    }
}
