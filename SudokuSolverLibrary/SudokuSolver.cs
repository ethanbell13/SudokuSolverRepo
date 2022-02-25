using System;
using System.Linq;
using System.Collections.Generic;
namespace SudokuLibrary
{
    public class SudokuSolver
    {
        char[][] sudokuArrays;
        int[][] blankSpots;
        int blankCount;
        Dictionary<string, int[]> arrayLinker;
        Dictionary<string, char[]> notes;
        bool valueAdded = true;
        public void sudokusolversolution(char[][] board)
        {
            var sudokuTuple = BoardOrganizer.BoardOrganizerSolution(board);
            sudokuArrays = sudokuTuple.Item1;
            arrayLinker = sudokuTuple.Item2;
            blankSpots = sudokuTuple.Item3;
            blankCount = sudokuTuple.Item4;
            SudokuValidater.SudokuValidatorSolution(sudokuArrays);
            notes = new Dictionary<string, char[]>();
            var x = blankCount;
            for (int i = 0; i < x; i++)
                NoteCreator(blankSpots[i][0], blankSpots[i][1]);
            while(blankCount != 0 && valueAdded == true)
            {
                for(int i = 1; i < 10; i++)
                {
                    ScanByNumber(Convert.ToChar(num + '0'));
                }
                foreach (KeyValuePair<string, char[]> entry in notes)
                {
                    valueAdded = false;
                    NoteCreator(entry.Key[0] - '0', entry.Key[1] - '0');

                }
            }
            //When adding a number, I should add it to any relevant existing notes. If this brings note total to 8,
            //I should call AddNumber.
        }
        void AddNum(char num, int row, int col)
        {
            valueAdded = true;
            var copositions = arrayLinker[row.ToString() + col.ToString()];
            sudokuArrays[row][col] = num;
            sudokuArrays[copositions[0]][copositions[1]] = num;
            sudokuArrays[copositions[2]][copositions[3]] = num;
            notes.Remove(row.ToString() + col.ToString());
            blankCount--;
        }
        void ScanByNumber(char c)
        {
            for(int i = 18; i < 27; i++)
            {
                var block = sudokuArrays[i];
                if(block.Contains(c))
                    break;
                var openSpots = new string[9]();
                var count = 0;
                for(int j; j < 9; j++)
                {
                    var str = i.ToString() + j.ToString();
                    var coPositions = arrayLinker[str];
                    if(block[j] == ' ' && !sudokuArrays[coPositions[0]].Contains(c) && !sudokuArrays[coPositions[2].Contains(col))
                    {
                        openSpots[count] = str;
                        count++;
                    }
                }
                if(count == 1)
                {
                    var coPositions = arrayLinker[openSpots[0]];
                    AddNum(c, coPositions[0], coPositions[1]);   
                }
            }
        }
        void ArrayFiller(int arrayNum)
        {
            var sudokuArray = sudokuArrays[arrayNum];
            var num = 45;
            var count = 0;
            foreach (char c in sudokuArray)
            {
                if (c != ' ')
                {
                    count++;
                    num -= c - '0';
                }
            }
            if (count == 8)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (sudokuArray[i] == ' ')
                    {
                        AddNum(Convert.ToChar(num + '0'), arrayNum, i);
                        break;
                    }
                }
            }
        }
        void NoteCreator(int row, int col)
        {
            var blockNum = arrayLinker[row.ToString() + col.ToString()][2];
            var note = new char[9];
            var noteCount = 0;
            var num = 45;
            var solved = false;
            for (int j = 0; j < 1; j++)
            {
                foreach (char c in sudokuArrays[row])
                {
                    if (c != ' ')
                    {
                        note[noteCount] = c;
                        num -= c - '0';
                        noteCount++;
                        if (noteCount == 8)
                        {
                            solved = true;
                            break;
                        }
                    }
                }
                foreach (char c in sudokuArrays[col + 9])
                {
                    if (c != ' ' && !note.Contains(c))
                    {
                        note[noteCount] = c;
                        num -= c - '0';
                        noteCount++;
                        if (noteCount == 8)
                        {
                            solved = true;
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
                            solved = true;
                            break;
                        }
                    }
                }
                if (!notes.ContainsKey(row.ToString() + col.ToString()))
                    notes.Add(row.ToString() + col.ToString(), note);

                if (solved == true)
                    AddNum(Convert.ToChar(num + '0'), row, col);
            }
        }
        bool BoardSurveyer()
        {
            foreach (KeyValuePair<string, char[]> entry in notes)
            {

            }
            return false;
        }
    }
}
