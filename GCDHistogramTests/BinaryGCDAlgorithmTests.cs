using GCDHistogram;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDHistogramTests
{
    [TestClass]
    public class BinaryGCDAlgorithmTests
    {
        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberEqualsSecondNumber_ReturnsFirstNumber()
        {
            // Arrange
            uint firstNumber = 15;
            uint secondNumber = 15;
            var expectedResult = firstNumber;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberEqualsZero_ReturnsSecondNumber()
        {
            // Arrange
            uint firstNumber = 0;
            uint secondNumber = 15;
            var expectedResult = secondNumber;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfSecondNumberEqualsZero_ReturnsFirstNumber()
        {
            // Arrange
            uint firstNumber = 15;
            uint secondNumber = 0;
            var expectedResult = firstNumber;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberEqualsOne_ReturnsOne()
        {
            // Arrange
            uint firstNumber = 1;
            uint secondNumber = 2;
            var expectedResult = firstNumber;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfSecondNumberEqualsOne_ReturnsOne()
        {
            // Arrange
            uint firstNumber = 2;
            uint secondNumber = 1;
            var expectedResult = secondNumber;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberIsSixAndSeconNumberIsThree_ReturnsThree()
        {
            // Arrange
            uint firstNumber = 6;
            uint secondNumber = 3;
            uint expectedResult = 3;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberIsThreeAndSeconNumberIsSix_ReturnsThree()
        {
            // Arrange
            uint firstNumber = 3;
            uint secondNumber = 6;
            uint expectedResult = 3;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberIsFourAndSeconNumberIsTwo_ReturnsTwo()
        {
            // Arrange
            uint firstNumber = 4;
            uint secondNumber = 2;
            uint expectedResult = 2;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberIsThreeAndSeconNumberIsFifteen_ReturnsThree()
        {
            // Arrange
            uint firstNumber = 3;
            uint secondNumber = 15;
            uint expectedResult = 3;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_IfFirstNumberIsFifteenAndSeconNumberIsThree_ReturnsThree()
        {
            // Arrange
            uint firstNumber = 15;
            uint secondNumber = 3;
            uint expectedResult = 3;
            double time;
            // Act
            var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_WhenFirstNumberIsZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            uint firstNumber = 15;
            double time;
            // Act
            try
            {
                var result = BinaryGCDAlgorithm.GetGreatestCommonDivisor(out time, firstNumber);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BinaryGCDAlgorithm.ShouldBeSeveralParameters);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

    }
}
