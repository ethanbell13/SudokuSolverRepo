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
                    notes.Add((j + 9).ToString() + iStr, "123456789");
                    notes.Add(blockNum.ToString() + blockPos.ToString(), "123456789");
                }
            }
        }
        void InputBoard(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] != ' ')
                    {
                        AddNum(board[i][j], i, j);
                    }
                }
            }
        }
        void AddNum(char num, int array, int pos)
        {
            var coPositions = arrayLinker[array.ToString() + pos.ToString()];
            sudokuArrays[array][pos] = num;
            sudokuArrays[coPositions[0]][coPositions[1]] = num;
            sudokuArrays[coPositions[2]][coPositions[3]] = num;
            notes.Remove(array.ToString() + pos.ToString());
            notes.Remove(coPositions[0].ToString() + coPositions[1].ToString());
            notes.Remove(coPositions[2].ToString() + coPositions[3].ToString());
            EditNotes(num, array);
            EditNotes(num, coPositions[0]);
            EditNotes(num, coPositions[2]);
        }
        void EditNotes(char num, int array, string[] exceptions = null)
        {
            for (int i = 0; i < 9; i++)
            {
                var coPositions = arrayLinker[array.ToString() + i.ToString()];
                var str = array.ToString() + i.ToString();
                if (exceptions != null && exceptions.Contains(str))
                    continue;
                else if (sudokuArrays[array][i] == '\0' && notes[str].Contains(num))
                {
                    var note = notes[str];
                    var index = note.IndexOf(num);
                    note = note.Remove(index, 1);
                    if (note.Length == 1)
                    {
                        AddNum(note[0], array, i);
                        valueAdded = true;
                    }
                    else
                    {
                        notes[str] = note;
                        notes[coPositions[0].ToString() + coPositions[1].ToString()] = note;
                        notes[coPositions[2].ToString() + coPositions[3].ToString()] = note;
                        valueAdded = true;
                        if (note.Length <= 4)
                        {
                            NakedCandidates(array, i, note);
                            NakedCandidates(coPositions[0], coPositions[1], note);
                            NakedCandidates(coPositions[2], coPositions[3], note);
                        }
                    }
                }
            }
        }
        Tuple<int, string, string> FindOtherCandidate(int array, int pos, int curPos, string note)
        {
            for(int i = curPos + 1; i < 9; i++)
            {
                if (sudokuArrays[array][i] != '\0' || pos == i)
                    continue;
                var contains = true;
                var curStr = array.ToString() + i.ToString();
                var curNote = notes[curStr];
                foreach (char c in curNote)
                {
                    if (!note.Contains(c))
                    {
                        contains = false;
                        break;
                    }
                }
                if (!contains)
                    continue;
                return Tuple.Create(i, curStr, curNote);
            }
            return Tuple.Create(0, "", "");
        }
        void NakedCandidates(int array, int pos, string note)
        {
            //An error in the logic is causing this method to call EditNotes when there are less exceptions than the
            //length of the note. 
            //With the way this is programmed, this method won't find these {"1,2", "1,3,2", 1"3" if the 
            //method is called for the  paris after the triplet calls the method
            //I should look more into developing tests before moving forward with this
            var y = 2;
            if (array == 3 && pos == 0 && note == "57")
                y = 2;
            var newPos = pos;
            var exceptions = new string[4];
            exceptions[0] = array.ToString() + pos.ToString();
            var candidateNotes = new string[4];
            candidateNotes[0] = note;
            var coArray1 = arrayLinker[array.ToString() + pos.ToString()][0];
            var coArray2 = arrayLinker[array.ToString() + pos.ToString()][2];
            var shared1 = true;
            var shared2 = true;
            for (int i = 1; i < note.Length; i++)
            {
                var tuple = FindOtherCandidate(array, pos, newPos, note);
                if (tuple.Item1 == 0)
                    return;
                newPos = tuple.Item1;
                exceptions[i] = tuple.Item2;
                candidateNotes[i] = tuple.Item3;
            }
		    for(int i = 0; i < note.Length; i++)
            {
                EditNotes(note[i], array, exceptions);
                if (coArray1 != arrayLinker[exceptions[i]][0])
                    shared1 = false;
                if(coArray2 != arrayLinker[exceptions[i]][2])
                    shared2 = false;
            }
            if (shared1)
            {
                array = coArray1;
                for (int i = 0; i < note.Length; i++)
                {
                    var coPositions = arrayLinker[exceptions[i]];
                    exceptions[i] = coPositions[0].ToString() + coPositions[1].ToString();
                }
            }
            else if (shared2)
            {
                if (coArray2 == 21)
                    y = 2;
                array = coArray2;
                for (int i = 0; i < note.Length; i++)
                {
                    var coPositions = arrayLinker[exceptions[i]];
                    exceptions[i] = coPositions[2].ToString() + coPositions[3].ToString();
                }
            }
            else
                return;
            for (int i = 0; i < note.Length; i++)
                EditNotes(note[i], array, exceptions);
        }
        void OnlyCellForNum(char num, int array)
        {
            var count = 0;
            int pos = 0;
            for (int i = 0; i < 9; i++)
            {
                if (sudokuArrays[array][i] == '\0')
                {
                    var str = array.ToString() + i.ToString();
                    if (!notes[array.ToString() + i.ToString()].Contains(num))
                    {
                        count++;
                        pos = i;
                    }
                }
                if (count > 1)
                    return;
            }
            AddNum(num, array, pos);
        }
        void ScanByBox(char num)
        {
            var array = 0;
            for (int i = 18; i < 27; i++)
            {
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
                    var row = coPositions[0];
                    if (block[j] == '\0' && notes[str].Contains(num))
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
                    var row = arrayLinker[openSpots[0]][0];
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
                        if (array < 9)
                            exceptions[j] = coPositions[0].ToString() + coPositions[1].ToString();
                        else
                            exceptions[j] = coPositions[2].ToString() + coPositions[3].ToString();
                        EditNotes(num, array, exceptions);
                    }
                }
            }
        }
        public void SudokuSolverSolution(char[][] board)
        {
            BoardValidator.ArgumentValidator(board);
            InitializeFields();
            InputBoard(board);
            BoardValidator.SudokuValidator(sudokuArrays);
            //while (valueAdded == true)
            //{
            //    valueAdded = false;
            //    for (int i = 1; i < 10; i++)
            //        ScanByBox(Convert.ToChar(i + '0'));
            //}
        }
    }
}
