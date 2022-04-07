using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuTestLibrary
{
    [TestClass]
    public class InitializationTests
    {
        [TestMethod]
        public void NineBy9ArrayIn27By9ArayOut()
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
            var expected = new char[27][]
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
            var result = SudokuLibrary.BoardOrganizer.BoardOrganizerSolution(input).Item1;
            var test = true;
            for(int i = 0; i < 27; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (result[i][j] != expected[i][j])
                        test = false;
                }
            }
            Assert.AreEqual(true, test);
        }
    }
}
