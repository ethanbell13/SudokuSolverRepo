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
            SudokuLibrary.BoardOrganizer.BoardOrganizerSolution(input);
            var y - 2;
    }
}
