using System;

namespace SudokuSolverLibrary
{
    public static class SudokuSolver
    {
        public static void sudokusolversolution(string[,] board)
        {
            if (board.GetLength(0) != 9 || board.GetLength(1) != 9)
                throw new Exception("Must be a 9 x 9 array.");
            //create more exception blocks
            var solved = false;
            while(solved == false)
            {
             for(int i = 0; i < 9; i++)
                {
                    for(int j = 0; j < 9; j++)
                    {

                    }
                }






            }
        }
    }
}
