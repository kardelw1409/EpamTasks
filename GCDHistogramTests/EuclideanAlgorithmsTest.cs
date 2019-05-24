using System;
using GCDHistogram;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCDHistogramTests
{
    [TestClass]
    public class EuclideanAlgorithmsTest
    {
        [TestMethod]
        public void CalculateGCDOfBinary_FindGCD5And15_Result5()
        {
            //Arrange
            uint firstNumber = 5;
            uint secondNumber = 15;
            double time;
            //Act
            var result = EuclideanAlgorithms.CalculateGCDOfBinary(out time, firstNumber, secondNumber);
            //Assert
            Assert.AreEqual(5, result, 0.001, "Invalid value in CalculateBinaryGCD method");
        }

        [TestMethod]
        public void CalculateGCDOfBinary_FindGCD5And15And20_Result5()
        {
            //Arrange
            uint firstNumber = 5;
            uint secondNumber = 15;
            uint thirdNumber = 20;
            double time;
            //Act
            var result = EuclideanAlgorithms.CalculateGCDOfBinary(out time, firstNumber, secondNumber, thirdNumber);
            //Assert
            Assert.AreEqual(5, result, 0.001, "Invalid value in CalculateBinaryGCD method");
        }

        [TestMethod]
        public void CalculateGCD_FindGCD24And32_Result8()
        {
            //Arrange
            uint firstNumber = 24;
            uint secondNumber = 32;
            double time;
            //Act
            var result = EuclideanAlgorithms.CalculateGCD(out time, firstNumber, secondNumber);
            //Assert
            Assert.AreEqual(8, result, 0.001, "Invalid value in CalculateGCD method");
        }

        [TestMethod]
        public void CalculateGCD_FindGCD100And25And125_Result25()
        {
            //Arrange
            uint firstNumber = 100;
            uint secondNumber = 25;
            uint thirdNumber = 125;
            double time;
            //Act
            var result = EuclideanAlgorithms.CalculateGCD(out time, firstNumber, secondNumber, thirdNumber);
            //Assert
            Assert.AreEqual(25, result, 0.001, "Invalid value in CalculateGCD method");
        }
    }
}
