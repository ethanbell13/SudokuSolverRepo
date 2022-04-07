using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SudokuTestLibrary
{
    [TestClass]
    public class BoardValidatorTests
    {
        [TestMethod]
        public void JaggedArrayLengthTest()
        {
            var input = new char[2][] { new char[2] { '1', '2' }, new char[2] { '1', '2' } };
            Assert.ThrowsException<ArgumentException>(() => SudokuLibrary.BoardValidator.ArgumentValidator(input));
        }
        [TestMethod]
        public void CharZInExceptionOut()
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
                new char[9] {' ', ' ', ' ', ' ', '8', ' ', ' ', '7', 'Z' }
            };
            Assert.ThrowsException<ArgumentException>(() => SudokuLibrary.BoardValidator.ArgumentValidator(input));
        }
        [TestMethod]
        public void Two9sInSameBoxOutputExcpeton()
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
                new char[9] {' ', ' ', ' ', ' ', '8', ' ', '9', '7', '9' }
            };
            Assert.ThrowsException<ArgumentException>(() => SudokuLibrary.BoardValidator.SudokuValidator(input));
        }
    }
}
