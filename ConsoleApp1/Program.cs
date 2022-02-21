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
                new char[9] {' ', ' ', ' ', ' ', '6', '2', '3', ' ', ' ' },
                new char[9] {'3', '4', '9', ' ', '1', ' ', '7', ' ', ' ' },
                new char[9] {' ', '5', ' ', '4', '3', ' ', ' ', ' ', '1' },
                new char[9] {' ', ' ', '2', '6', '5', ' ', ' ', ' ', '9' },
                new char[9] {' ', ' ', '8', ' ', '4', ' ', '1', '6', '2' },
                new char[9] {' ', '6', '4', '2', '9', '1', ' ', '3', '8' },
                new char[9] {' ', ' ', ' ', ' ', ' ', '6', ' ', ' ', ' ' },
                new char[9] {' ', '8', ' ', ' ', '7', ' ', ' ', '5', '4' },
                new char[9] {'9', ' ', ' ', '3', '2', ' ', '6', ' ', '7' } 
            };
            var x = new SudokuLibrary.SudokuSolver();
            x.sudokusolversolution(input);
            var testDict = new Dictionary<string, string>();
            testDict["a"] = "b";
            Console.WriteLine(testDict["a"]);
            var h = 2;
            //modify array filler so that it takes in numbers from corresponding arrays that aren't in the primary array. I can create
            //an array that stores all unique numbers for comparison purposes and continue to subtract from variable num until count == 8

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