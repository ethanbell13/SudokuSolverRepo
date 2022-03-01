using System;
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
            var copositions = arrayLinker[row.ToString() + col.ToString()];
            sudokuArrays[row][col] = num;
            sudokuArrays[copositions[0]][copositions[1]] = num;
            sudokuArrays[copositions[2]][copositions[3]] = num;
            notes.Remove(row.ToString() + col.ToString());
            EditNotes(num, row, col);
        }
        void EditNotes(char num, int sudokuArray, int col)
        {
            for (int i = 0; i < 9; i++)
            {
                var coPosistions = arrayLinker[sudokuArray.ToString() + i.ToString()];
                if(sudokuArray < 9)
                {
                    var str = sudokuArray.ToString() + i.ToString();
                    var note = notes[str];
                    if (note.Contains(num))
                    {
                        var index = note.IndexOf(num);
                        note = note.Remove(index, 1);
                        if (note.Length == 1)
                            AddNum(num, sudokuArray, col);
                        else
                            notes[str] = note;
                    }

                }
            }
        }
        public static void BoardValidator(char[][] sudokuArrays)
        {
            foreach (char[] array in sudokuArrays)
            {
                var currentArray = new char[9];
                for (int i = 0; i < 9; i++)
                {
                    if (array[i] != ' ' && array[i] != '\0' && currentArray.Contains(array[i]))
                        throw new ArgumentException("This is not a valid sudoku board.");
                    currentArray[i] = array[i];
                }
            }
        }
        void ScanByNumber(char c)
        {
            for (int i = 18; i < 27; i++)
            {
                var block = sudokuArrays[i];
                if (block.Contains(c))
                    continue;
                var openSpots = new string[9];
                var count = 0;
                for (int j = 0; j < 9; j++)
                {
                    var str = i.ToString() + j.ToString();
                    var coPositions = arrayLinker[str];
                    if (block[j] == '\0' && !sudokuArrays[coPositions[0]].Contains(c) && !sudokuArrays[coPositions[2]].Contains(c))
                    {
                        openSpots[count] = str;
                        count++;
                    }
                }
                if (count == 1)
                {
                    var coPositions = arrayLinker[openSpots[0]];
                    AddNum(c, coPositions[0], coPositions[1]);
                    valueAdded = true;
                }
                else if (count <= 3)
                {
                    var row= arrayLinker[openSpots[0]][0];
                    var col = arrayLinker[openSpots[0]][1];
                    if((arrayLinker[openSpots[1]][0] == row || arrayLinker[openSpots[1]][1] == col) ||
                        ((arrayLinker[openSpots[1]][0] == row && arrayLinker[openSpots[2]][0] == row) || 
                        (arrayLinker[openSpots[1]][1] == col && arrayLinker[openSpots[2]][2] == col)))
                    {
                        
                    }
                    else if (count == 2)
                    {

                    }
                    
                }
                else if (count == 2)
                {

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
