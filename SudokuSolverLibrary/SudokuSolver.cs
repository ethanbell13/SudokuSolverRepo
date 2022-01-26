using System;
using System.Linq;
namespace SudokuSolverLibrary
{
    public static class SudokuSolver
    {
        public static void sudokusolversolution(char[][] board)
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
        static void AddNum (char num, int row, int col)
        {
            organizedBoard[row][col] = num;
            organizedBoard[col][row[ = num;
            if(row <= 2)
            {
                if(col <= 2)
                    block = 18;
                else if(col <= 5)
                    block = 19;
                else
                    block = 20;
            }
            else if(row <= 5)
            {
                if(col <= 2)
                    block = 21
                else if(col <= 5)
                    block = 22
                else
                    block = 23
            }
            else
            {
                if(col <= 2)
                    block = 24
                else if(col <= 5)
                    block = 25
                else
                    block = 26
            }
            
        }
        static void RowFiller(char[][] organizedBoard)
        {
            for(int i = 0; i < 9; i++)
            {
                var num = 45;
                var count = 0;
                for(int j = 0; j < 9; j++)
                {
                    if(organizeBoard[i][j] != ' ')
                    {
                        count += 1;
                        num -= ToInt32(organizedBoard[i][j]);
                    }    
                    else if(count == 8)
                    {    
                        organizedBoard[i][j] = num;
                        organizedBoard[j + 9][i] = num;
                        
                    }  
                }
            }
        }
        //uncomplete. Try swapping the boxes out for columns. Functionally, there shouldn't be a difference, and it would make
        //keeping tack of locating and editing much easier
        static void IdentificationByNumbers(char[][] organizedBoard)
        {
            for(int i = 1; i <= 9; i++)
            {
                var num = char.Parse(i.ToString());
                for (int j = 0; j <= 9; j++)
                {
                    if(!organizedBoard[17 + j].Contains(num))
                    {
                        var block = organizedBoard[17 + j];
                        var canBeNum = new bool[9] { true, true, true, true, true, true, true, true, true };
                        var numLocation = 99;
                        for(int k = 0; k < 9; k++)
                        {
                            if (block[k] != ' ')
                            {
                                canBeNum[k] = false;
                            }
                        }
                        if (organizedBoard[0].Contains(num))
                        {
                            canBeNum[0] = false;
                            canBeNum[1] = false;
                            canBeNum[2] = false;

                        }
                        if (organizedBoard[1].Contains(num))
                        {
                            canBeNum[3] = false;
                            canBeNum[4] = false;
                            canBeNum[5] = false;
                        }
                        if (organizedBoard[2].Contains(num))
                        {
                            canBeNum[6] = false;
                            canBeNum[7] = false;
                            canBeNum[8] = false;
                        }
                        if (organizedBoard[9].Contains(num))
                        {
                            canBeNum[0] = false;
                            canBeNum[3] = false;
                            canBeNum[6] = false;
                        }
                        if (organizedBoard[10].Contains(num))
                        {
                            canBeNum[1] = false;
                            canBeNum[4] = false;
                            canBeNum[7] = false;
                        }
                        if (organizedBoard[11].Contains(num))
                        {
                            canBeNum[2] = false;
                            canBeNum[5] = false;
                            canBeNum[8] = false;
                        }
                        for(int l = 0; l < 9; l++)
                        {
                            if(canBeNum[l] == true)
                            {
                                if (numLocation == 99)
                                    numLocation = l;
                                else
                                {
                                    numLocation = 99;
                                    break;
                                }
                            }
                        }
                        if(numLocation != 99)
                        {
                            if(j < 3)
                            {

                            }
                        }


                    }


                }
            }
                
        }
    }
}
