using System;
using System.Linq;
namespace SudokuSolverLibrary
{
    public class SudokuSolver
    {
        char[][] board;
        char[][] sudokuArrays;
        public void sudokusolversolution(char[][] sudokuBoard)
        {
            SudokuLibrary.SudokuValidater.SudoukuValidatorSolution(sudokuBoard);
            sudokuArrays = SudokuLibrary.BoardOrganizer.BoardOrganizerSolution(sudokuBoard);
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
        void AddNum (char num, int arrayNum, int position)
        {
            sudokuArrays[arrayNum][position] = num;
            if (arrayNum < 18)
            {
                if(arrayNum < 9) 
                {
                    sudokuArrays[arrayNum + position][arrayNum] = num;
                }
            }
        }
        void ArrayFiller(int arrayNum)
        {
            var sudokuArray = sudokuArrays[arrayNum];
            var num = 45;
            var count = 0;
            foreach(char c in sudokuArray)
            {
                if (c != ' ')
                    count ++;
                    num -= Convert.ToInt32(c);
            }
            if(count == 8)
            {
                for(int i = 0; i < 9; i++)
                {
                    if(sudokuArray[i] == ' ')
                    {
                        AddNum(Convert.ToChar(num), arrayNum, i);
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
