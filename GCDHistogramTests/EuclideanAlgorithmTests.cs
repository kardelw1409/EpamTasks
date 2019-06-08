using System;
using GCDHistogram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCDHistogramTests
{
    [TestClass]
    public class EuclideanAlgorithmTests
    {
        [TestMethod]
        public void GetGreatestCommonDivisor_WhenFirstNumberIsZero_ShouldThrowArithmetic()
        {
            //Arrange
            uint firstNumber = 0;
            uint secondNumber = 15;
            double time;
            // Act
            try
            {
                var result = EuclideanAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            }
            catch (System.ArithmeticException e)
            {
                // Assert
                StringAssert.Contains(e.Message, EuclideanAlgorithm.TheNumberShouldBeNonZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_WhenSecondNumberIsZero_ShouldThrowArithmetic()
        {
            //Arrange
            uint firstNumber = 15;
            uint secondNumber = 0;
            double time;
            // Act
            try
            {
                var result = EuclideanAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            }
            catch (System.ArithmeticException e)
            {
                // Assert
                StringAssert.Contains(e.Message, EuclideanAlgorithm.TheNumberShouldBeNonZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_WhenBothNumbersAreZero_ShouldThrowArithmetic()
        {
            //Arrange
            uint firstNumber = 0;
            uint secondNumber = 0;
            double time;
            // Act
            try
            {
                var result = EuclideanAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            }
            catch (System.ArithmeticException e)
            {
                // Assert
                StringAssert.Contains(e.Message, EuclideanAlgorithm.TheNumberShouldBeNonZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_WhenBothNumbersAreNotZero_ShouldNotThrowArithmetic()
        {
            //Arrange
            uint firstNumber = 2;
            uint secondNumber = 6;
            double time;
            // Act
            try
            {
                var result = EuclideanAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            }
            catch (System.ArithmeticException e)
            {
                // Assert
                StringAssert.Contains(e.Message, EuclideanAlgorithm.TheNumberShouldBeNonZeroMessage);
                return;
            }
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_NumberTwoAndNumberSix_ReturnsTwo()
        {
            //Arrange
            uint firstNumber = 2;
            uint secondNumber = 6;
            uint expectedResult = 2;
            double time;
            // Act
            var result = EuclideanAlgorithm.GetGreatestCommonDivisor(out time, firstNumber, secondNumber);
            // Assert
            Assert.AreEqual(expectedResult, result, 0.001, "GCD is incorrectly counted");
        }

        [TestMethod]
        public void GetGreatestCommonDivisor_WhenOneParameter_ShouldThrowArgumentOutOfRange()
        {
            //Arrange
            uint firstNumber = 15;
            double time;
            // Act
            try
            {
                var result = EuclideanAlgorithm.GetGreatestCommonDivisor(out time, firstNumber);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, EuclideanAlgorithm.ShouldBeSeveralParameters);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

    }
}
