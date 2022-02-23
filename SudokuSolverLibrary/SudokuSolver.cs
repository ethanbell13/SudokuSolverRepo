using System;
using System.Linq;
using System.Collections.Generic;
namespace SudokuLibrary
{
    public class SudokuSolver
    {
        char[][] sudokuArrays;
        Dictionary<string, int[]> arrayLinker;
        int blankCount;
        int[][] blankSpots;
        Dictionary<string, char[]> notes;
        public void sudokusolversolution(char[][] sudokuBoard)
        {
            SudokuValidater.SudoukuValidatorSolution(sudokuBoard);
            var sudokuTuple = BoardOrganizer.BoardOrganizerSolution(sudokuBoard);
            sudokuArrays = sudokuTuple.Item1;
            arrayLinker = sudokuTuple.Item2;
            blankCount = sudokuTuple.Item3;
            blankSpots = sudokuTuple.Item4;
            notesInit();
             for(int i = 0; i < 27; i++)
                {
                    ArrayFiller(i);
                }
        }
        void AddNum (char num, int arrayNum, int pos)
        {
            var copositions = arrayLinker[arrayNum.ToString() + pos.ToString()];
            sudokuArrays[arrayNum][pos] = num;
            sudokuArrays[copositions[0]][copositions[1]] = num;
            sudokuArrays[copositions[2]][copositions[3]] = num;
        }
        void ArrayFiller(int arrayNum)
        {
            var sudokuArray = sudokuArrays[arrayNum];
            var num = 45;
            var count = 0;
            foreach(char c in sudokuArray)
            {
                if (c != ' ')
                {
                    count++;
                    num -= c - '0';
                }
            }
            if(count == 8)
            {
                for(int i = 0; i < 9; i++)
                {
                    if(sudokuArray[i] == ' ')
                    {
                        AddNum(Convert.ToChar(num + '0'), arrayNum, i);
                        break;
                    }
                }
            }
        }
        void notesInit()
        {
            notes = new Dictionary<string, char[]>();
            var solved = 0;
            for (int i = 0; i < blankCount; i++)
            {
                var rowNum = blankSpots[i][0];
                var colNum = blankSpots[i][1];
                var blockNum = arrayLinker[rowNum.ToString() + colNum.ToString()][2];
                var note = new char[9];
                var noteCount = 0;
                var num = 45;
                for (int j = 0; j < 1; j++)
                {
                    foreach (char c in sudokuArrays[rowNum])
                    {
                        if (c != ' ')
                        {
                            note[noteCount] = c;
                            num -= c - '0';
                            noteCount++;
                            if (noteCount == 8)
                            {
                                AddNum(Convert.ToChar(num + '0'), rowNum, colNum);
                                solved++;
                                break;
                            }
                        }
                    }
                    foreach (char c in sudokuArrays[colNum + 9])
                    {
                        if (c != ' ' && !note.Contains(c))
                        {
                            note[noteCount] = c;
                            num -= c - '0';
                            noteCount++;
                            if (noteCount == 8)
                            {
                                AddNum(Convert.ToChar(num + '0'), rowNum, colNum);
                                solved++;
                                break;
                            }
                        }
                    }
                    foreach (char c in sudokuArrays[blockNum])
                    {
                        if (c != ' ' && !note.Contains(c))
                        {
                            note[noteCount] = c;
                            num -= c - '0';
                            noteCount++;
                            if (noteCount == 8)
                            {
                                AddNum(Convert.ToChar(num + '0'), rowNum, colNum);
                                solved++;
                                break;
                            }
                        }
                    }
                    notes.Add(rowNum.ToString() + colNum.ToString(), note);
                }
            }
            blankCount -= solved;
        }
        //bool BoardSurveyer()
        //{
        //    var solved = 0;
        //    for ()
        //    {

        //    }
        //    return false;
        //}
    }
}
