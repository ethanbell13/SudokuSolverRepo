﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuLibrary
{
    public class BoardOrganizer
    {
        //Orgainzed the soduku board into a jaggedd array with 27 arrays of 9 characters. Rows = Arrays 0-8,
        //Columns = Arrays 9-17, and Squares = Arrays 18-26.
        public static char[][] BoardOrganizerSolution(char[][] board)
        {

            var sudokuArrays = new char[27][];
            for (int i = 0; i < 9; i++)
                sudokuArrays[i] = board[i];
            for(int i = 0; i < 9; i++)
            {
                var col = new char[9];
                for (int j = 0; j < 9; j++)
                    col[j] = board[j][i];
                sudokuArrays[i + 9] = col;
            }
            var x = 0;
            for (int i = 0; i < 9; i += 3) 
            {
                for (int j = 0; j < 9; j += 3)
                {
                    var block = new char[9];
                    block[0] = board[i][j];
                    block[1] = board[i][j + 1];
                    block[2] = board[i][j + 2];
                    block[3] = board[i + 1][j];
                    block[4] = board[i + 1][j + 1];
                    block[5] = board[i + 1][j + 2];
                    block[6] = board[i + 2][j];
                    block[7] = board[i + 2][j + 1];
                    block[8] = board[i + 2][j + 2];
                    sudokuArrays[x + 18] = block;
                    x++;
                }
            }
            return sudokuArrays;
        }
    }
}
