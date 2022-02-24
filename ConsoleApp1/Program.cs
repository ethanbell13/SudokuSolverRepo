using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new char[9][]
             {
                //Integrate method that finds values based on what spaces are available in a box for a given number
                new char[9] {' ', ' ', ' ', ' ', ' ', '9', '6', ' ', '5' },
                new char[9] {' ', ' ', ' ', '1', '6', ' ', '7', ' ', ' ' },
                new char[9] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[9] {'4', ' ', ' ', ' ', '1', '3', ' ', ' ', '8' },
                new char[9] {'9', ' ', '1', '6', '8', ' ', '3', ' ', '2' },
                new char[9] {' ', ' ', '8', ' ', ' ', '4', ' ', '9', '7' },
                new char[9] {'8', '1', ' ', ' ', ' ', ' ', ' ', '2', '6' },
                new char[9] {' ', '9', '4', '7', ' ', ' ', '8', ' ', ' ' },
                new char[9] {' ', ' ', '5', ' ', ' ', '1', '4', ' ', ' ' }
             };
            var x = new SudokuLibrary.SudokuSolver();
            x.sudokusolversolution(input);
            var h = 2;
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