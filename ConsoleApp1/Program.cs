using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = new char[9][]
            //{
            //    new char[9] {' ', '3', ' ', '1', ' ', ' ', ' ', '8', '4' },
            //    new char[9] {' ', '8', ' ', ' ', '4', ' ', '3', '9', ' ' },
            //    new char[9] {' ', '6', ' ', '8', ' ', ' ', ' ', ' ', ' ' },
            //    new char[9] {' ', ' ', '4', ' ', ' ', ' ', '8', ' ', ' ' },
            //    new char[9] {' ', '1', '3', ' ', ' ', ' ', ' ', '7', ' ' },
            //    new char[9] {' ', ' ', '2', '6', ' ', ' ', '5', '4', ' ' },
            //    new char[9] {' ', '2', ' ', ' ', ' ', ' ', '4', ' ', '5' },
            //    new char[9] {'1', ' ', ' ', ' ', ' ', '9', ' ', ' ', ' ' },
            //    new char[9] {' ', ' ', ' ', '5', '6', '1', '9', ' ', ' ' }
            // };
            //var x = new SudokuLibrary.SudokuSolver();
            //x.SudokuSolverSolution(input);
            //for (int i = 0; i < 9; i++)
            //{
            //    var row = "";
            //    for (int j = 0; j < 9; j++)
            //        row += x.sudokuArrays[i][j] + " ";
            //    Console.WriteLine(row);
            //}
            var z = "123";
            z += z[2] - 49;
            var x = z.Remove(2, 1);
            var y = 2;
        }
    }
}
//var input = new char[9][]
//            {
//                new char[9] {'5', '3', ' ', ' ', '7', ' ', ' ', ' ', ' ' },
//                new char[9] {'6', ' ', ' ', '1', '9', '5', ' ', ' ', ' ' },
//                new char[9] {' ', '9', '8', ' ', ' ', ' ', ' ', '6', ' ' },
//                new char[9] {'8', ' ', ' ', ' ', '6', ' ', ' ', ' ', '3' },
//                new char[9] {'4', ' ', ' ', '8', ' ', '3', ' ', ' ', '1' },
//                new char[9] {'7', ' ', ' ', ' ', '2', ' ', ' ', ' ', '6' },
//                new char[9] {' ', '6', ' ', ' ', ' ', ' ', '2', '8', ' ' },
//                new char[9] {' ', ' ', ' ', '4', '1', '9', ' ', ' ', '5' },
//                new char[9] {' ', ' ', ' ', ' ', '8', ' ', ' ', '7', '9' }
//            };