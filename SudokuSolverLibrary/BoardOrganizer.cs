using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public class BoardOrganizer
    {
        //Orgainzed the soduku board into a jaggedd array with 27 arrays of 9 characters. Rows = Arrays 0-8,
        //Columns = Arrays 9-17, and Blocks = Arrays 18-26.
        public static (char[][], Dictionary<string, int[]>, int, int[][]) BoardOrganizerSolution(char[][] board)
        {
            SudokuLibrary.SudokuValidater.ArgumentValidator(board);
            //arraylinker Key is position of a character in sudokuArrays and the values are the two other corresponding
            //array positions. ie. If you give it the position of the character in a row,
            //it tells you the character's positions in the corresponding column and box.
            var arrayLinker = new Dictionary<string, int[]>();
            var sudokuArrays = new char[27][];
            int blockNum = 0;
            int blockPos;
            var blankCount = 0;
            var blankSpots = new int[81][];
            //Add array connectons to dictionary as you add units to sudokuArrays
            for (int i = 0; i < 9; i++)
            {
                sudokuArrays[i] = new char[9];
                for (int j = 0; j < 9; j++)
                {
                    blockNum = 18 + (i / 3) * 3 + j / 3;
                    blockPos = (i % 3) * 3 + j % 3;
                    if (i == 0)
                        sudokuArrays[j + 9] = new char[9];
                    if(i % 3 == 0 && j % 3 == 0)
                    {
                        sudokuArrays[blockNum] = new char[9];
                    }
                    sudokuArrays[i][j] = board[i][j];
                    sudokuArrays[j + 9][i] = board[i][j];
                    sudokuArrays[blockNum][blockPos] = board[i][j];
                    var iStr = i.ToString();
                    var jStr = j.ToString();
                    var jMas9Str = (j + 9).ToString();
                    var blockNumStr = blockNum.ToString();
                    var blockPosStr = blockPos.ToString();
                    arrayLinker.Add
                        (iStr + jStr, new int[4] { j + 9, i, blockNum, blockPos });
                    arrayLinker.Add
                        (jMas9Str + iStr, new int[4] { i, j, blockNum, blockPos });
                    arrayLinker.Add
                        (blockNumStr + blockPosStr, new int[4] { i, j, j + 9, i });
                    if (board[i][j] == ' ')
                    {
                        blankSpots[blankCount] = new int[2] { i, j};
                        blankCount++;
                    }
                }
            }
            return (sudokuArrays, arrayLinker, blankCount, blankSpots);
        }
    }
}
