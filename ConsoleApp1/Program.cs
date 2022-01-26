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
                new char[9] {'5', '3', ' ', ' ', '7', ' ', ' ', ' ', ' ' },
                new char[9] {'6', ' ', ' ', '1', '9', '5', ' ', ' ', ' ' },
                new char[9] {' ', '9', '8', ' ', ' ', ' ', ' ', '6', ' ' },
                new char[9] {'8', ' ', ' ', ' ', '6', ' ', ' ', ' ', '3' },
                new char[9] {'4', ' ', ' ', '8', ' ', '3', ' ', ' ', '1' },
                new char[9] {'7', ' ', ' ', ' ', '2', ' ', ' ', ' ', '6' },
                new char[9] {' ', '6', ' ', ' ', ' ', ' ', '2', '8', ' ' },
                new char[9] {' ', ' ', ' ', '4', '1', '9', ' ', ' ', '5' },
                new char[9] {' ', ' ', ' ', ' ', '8', ' ', ' ', '7', '9' } 
            };
            SudokuLibrary.SudokuValidater.SudoukuValidatorSolution(input);
            
            var correctOutput = new char[27][]
            {
                new char[9] {'5', '3', ' ', ' ', '7', ' ', ' ', ' ', ' ' },
                new char[9] {'6', ' ', ' ', '1', '9', '5', ' ', ' ', ' ' },
                new char[9] {' ', '9', '8', ' ', ' ', ' ', ' ', '6', ' ' },
                new char[9] {'8', ' ', ' ', ' ', '6', ' ', ' ', ' ', '3' },
                new char[9] {'4', ' ', ' ', '8', ' ', '3', ' ', ' ', '1' },
                new char[9] {'7', ' ', ' ', ' ', '2', ' ', ' ', ' ', '6' },
                new char[9] {' ', '6', ' ', ' ', ' ', ' ', '2', '8', ' ' },
                new char[9] {' ', ' ', ' ', '4', '1', '9', ' ', ' ', '5' },
                new char[9] {' ', ' ', ' ', ' ', '8', ' ', ' ', '7', '9' },
                new char[9] {'5', '6', ' ', '8', '4', '7', ' ', ' ', ' ' },
                new char[9] {'3', ' ', '9', ' ', ' ', ' ', '6', ' ', ' ' },
                new char[9] {' ', ' ', '8', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[9] {' ', '1', ' ', ' ', '8', ' ', ' ', '4', ' ' },
                new char[9] {'7', '9', ' ', '6', ' ', '2', ' ', '1', '8' },
                new char[9] {' ', '5', ' ', ' ', '3', ' ', ' ', '9', ' ' },
                new char[9] {' ', ' ', ' ', ' ', ' ', ' ', '2', ' ', ' ' },
                new char[9] {' ', ' ', '6', ' ', ' ', ' ', '8', ' ', '7' },
                new char[9] {' ', ' ', ' ', '3', '1', '6', ' ', '5', '9' },
                new char[9] {'5', '3', ' ', '6', ' ', ' ', ' ', '9', '8' },
                new char[9] {' ', '7', ' ', '1', '9', '5', ' ', ' ', ' ' },
                new char[9] {' ', ' ', ' ', ' ', ' ', ' ', ' ', '6', ' ' },
                new char[9] {'8', ' ', ' ', '4', ' ', ' ', '7', ' ', ' ' },
                new char[9] {' ', '6', ' ', '8', ' ', '3', ' ', '2', ' ' },
                new char[9] {' ', ' ', '3', ' ', ' ', '1', ' ', ' ', '6' },
                new char[9] {' ', '6', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                new char[9] {' ', ' ', ' ', '4', '1', '9', ' ', '8', ' ' },
                new char[9] {'2', '8', ' ', ' ', ' ', '5', ' ', '7', '9' }
            };
            //var test = SudokuLibrary.SudokuValidater.SudoukuValidatorSolution(input);
            var y = new char[3] { '1', '2', '1' };
            var abc = "abczft";
            Console.WriteLine(abc.Count());
            var i = input[0][1];
            var state = new bool[3];
            state[0] = false;
            state[1] = false;
            for(int j = 0; j < 3; j++)
            {
                if(state[j] != false)
                {
                    Console.WriteLine("pass");
                }
            }
        }
    }
}
