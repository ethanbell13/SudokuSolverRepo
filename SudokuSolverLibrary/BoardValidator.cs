using System;
using System.Linq;

namespace SudokuLibrary
{
    public static class BoardValidator
    {
        public static void ArgumentValidator(char[][] board)
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
        public static void SudokuValidator(char[][] sudokuArrays)
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
    }
}
