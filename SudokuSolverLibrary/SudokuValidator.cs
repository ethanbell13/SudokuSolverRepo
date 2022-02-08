using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public static class SudokuValidater
    {
        public static void ArgumentValidator(char[][] board)
        {
            if(board.GetLength(0) != 9)
                throw new ArgumentException("Input must be jagged array of 27 character arrays with lengths of 9.");
            var values = new char[10] { ' ', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for(int i = 0; i < 9; i++)
            {
                if(board[i].Count() != 9)
                    throw new ArgumentException("Input must be jagged array of 27 character arrays with lengths of 9.");
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(!values.Contains(board[i][j]))
                        throw new ArgumentException("Each array element must be a number between 1-9 or ' '.");
                }
            }
        }

        public static void SudoukuValidatorSolution(char[][] board)
        {
            var sudokuArrays = BoardOrganizer.BoardOrganizerSolution(board);
            foreach(char[] array in sudokuArrays)
            {
                var currentArray = new char[9];
                for (int i = 0; i < 9; i++)
                {
                    if (array[i] != ' ' && currentArray.Contains(array[i]))
                        throw new ArgumentException("This is not a valid sudoku board.");
                    currentArray[i] = array[i];
                }
            }
        }
    }
}
