using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using MindBox;
using NUnit.Framework;

namespace UnitTests
{
    public class TriangleMathTests
    {
        [TestCase(0, 5, 5)]
        [TestCase(5, 0, 5)]
        [TestCase(5, 5, 0)]
        [TestCase(-5, 5, 5)]
        [TestCase(5, -5, 5)]
        [TestCase(5, 5, -5)]
        public void GetTriangleSquare_ZeroOrNegativeSide_ExceptionThrown(double side1, double side2, double side3)
        {
            var ex = Assert.Throws<ArgumentException>(() => TriangleMath.GetTriangleSquare(side1, side2, side3));
            Assert.AreEqual(ex.Message, "Sides length must be positive.");
        }

        [TestCase(10, 5, 5)]
        [TestCase(5, 10, 5)]
        [TestCase(5, 5, 10)]
        [TestCase(20, 5, 5)]
        [TestCase(5, 20, 5)]
        [TestCase(5, 5, 20)]
        public void GetTriangleSquare_SideMoreOrEqualThanSumOfOthers_ExceptionThrown(double side1, double side2, double side3)
        {
            var ex = Assert.Throws<ArgumentException>(() => TriangleMath.GetTriangleSquare(side1, side2, side3));
            Assert.AreEqual(ex.Message, "Every side must be less than sum of others.");
        }

        [TestCase(5, 5, 5, 10.825)]
        public void GetTriangleSquare_CorrectData_CorrectResult(double side1, double side2, double side3, double expectingResult)
        {
            //Arrange
            double epsilon = 1E-3;
            //Act
            var result = TriangleMath.GetTriangleSquare(side1, side2, side3);
            //Assert
            Assert.Less(Math.Abs(result - expectingResult), epsilon);
        }

        [TestCase(0, 5)]
        [TestCase(5, 0)]
        [TestCase(-5, 5)]
        [TestCase(5, -5)]
        public void GetRightTriangleSquareCathetusArgs_ZeroOrNegativeSide_ExceptionThrown(double cathetus1, double cathetus2)
        {
            var ex = Assert.Throws<ArgumentException>(() => TriangleMath.GetRightTriangleSquare(cathetus1, cathetus2));
            Assert.AreEqual(ex.Message, "Sides length must be positive.");
        }

        [TestCase(5, 5, 12.5)]
        public void GetRightTriangleSquareCathetusArgs_CorrectData_CorrectResult(double cathetus1, double cathetus2, double expectingResult)
        {
            //Arrange
            double epsilon = 1E-3;
            //Act
            var result = TriangleMath.GetRightTriangleSquare(cathetus1, cathetus2);
            //Assert
            Assert.Less(Math.Abs(result - expectingResult), epsilon);
        }
    }
}
