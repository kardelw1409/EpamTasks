using GeometryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProjectTests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArithmeticException),
            "Division by zero is impossible.")]
        public void Division_IfNumberIsZero_ShouldThrowArithmetic()
        {
            //Arrange
            var vector = new Vector(2, 5, 8);
            double number = 0;
            // Act
            var result = vector / number;
        }

        [TestMethod]
        public void Sum_IfAddFirstVectorToSecondVector_ReturnsThridVector()
        {
            // Arrange
            var firstVector = new Vector( 1, 3, 9 );
            var secondVector = new Vector( 6, 9, 7 );
            var thridVector = new Vector( 7, 12, 16 );
            // Act
            var result = firstVector + secondVector;
            // Assert
            Assert.AreEqual(thridVector, result);
        }

        [TestMethod]
        public void Difference_IfFromFirstVectorTakeSecondVector_ReturnsThridVector()
        {
            // Arrange
            var firstVector = new Vector(1, 3, 9);
            var secondVector = new Vector(6, 9, 7);
            var thridVector = new Vector(-5, -6, 2);
            // Act
            var result = firstVector - secondVector;
            // Assert
            Assert.AreEqual(thridVector, result);
        }

        [TestMethod]
        public void Multiple_IfFirstVectorMultipleToNumber_ReturnsThridVector()
        {
            // Arrange
            var firstVector = new Vector(1, 3, 9);
            var number = 5;
            var thridVector = new Vector(5, 15, 45);
            // Act
            var result = firstVector * number;
            // Assert
            Assert.AreEqual(thridVector, result);
        }

        [TestMethod]
        public void Multiple_IfFirstVectorMultipleToSecondVector_ReturnsNumber()
        {
            // Arrange
            var firstVector = new Vector(1, 3, 9);
            var secondVector = new Vector(2, 5, 9);
            var resultNumnber = 98;
            // Act
            var result = firstVector * secondVector;
            // Assert
            Assert.AreEqual(resultNumnber, result);
        }

        [TestMethod]
        public void Divide_IfFirstVectorDivideToNumber_ReturnsThridVector()
        {
            // Arrange
            var firstVector = new Vector(1, 3, 9);
            var number = 5;
            var thridVector = new Vector(0.2, 0.6, 1.8);
            // Act
            var result = firstVector / number;
            // Assert
            Assert.AreEqual(thridVector, result);
        }

        [TestMethod]
        public void GetAngleBetweenVectors_IfFindAngleBetweenFirstVectorAndSecondVector_ReturnsAngle()
        {
            // Arrange
            var firstVector = new Vector(0, 2, 0);
            var secondVector = new Vector(0, 0, 2);
            var resultAngle = Math.PI / 2;
            // Act
            var result = Vector.GetAngleBetweenVectors(firstVector, secondVector);
            // Assert
            Assert.AreEqual(resultAngle, result);
        }

    }
}
