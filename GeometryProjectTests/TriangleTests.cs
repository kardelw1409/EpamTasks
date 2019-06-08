using System;
using GeometryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryProjectTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Triangle_IfFirstSideIsnNegative_ShouldThrowArgument()
        {
            //Arrange
            double firstSide = -15;
            double secondSide = 18;
            double thridSide = 5;
            // Act
            try
            {
                new Triangle(firstSide, secondSide, thridSide);
            }
            catch (ArgumentException e)
            {
                // Assert
                StringAssert.Contains(e.Message, Triangle.ValueNeedsToBePositive);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Triangle_IfSecondSideIsnNegative_ShouldThrowArgument()
        {
            //Arrange
            double firstSide = 15;
            double secondSide = -18;
            double thridSide = 5;
            // Act
            try
            {
                new Triangle(firstSide, secondSide, thridSide);
            }
            catch (ArgumentException e)
            {
                // Assert
                StringAssert.Contains(e.Message, Triangle.ValueNeedsToBePositive);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Triangle_IfThridSideIsnNegative_ShouldThrowArgument()
        {
            //Arrange
            double firstSide = 15;
            double secondSide = 18;
            double thridSide = -5;
            // Act
            try
            {
                new Triangle(firstSide, secondSide, thridSide);
            }
            catch (ArgumentException e)
            {
                // Assert
                StringAssert.Contains(e.Message, Triangle.ValueNeedsToBePositive);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Triangle_IfFirstSideIsZero_ShouldThrowException()
        {
            //Arrange
            double firstSide = 0;
            double secondSide = 18;
            double thridSide = 10;
            // Act
            try
            {
                new Triangle(firstSide, secondSide, thridSide);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, Triangle.CannotCreateATriangleMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Triangle_IfSecondSideIsZero_ShouldThrowException()
        {
            //Arrange
            double firstSide = 15;
            double secondSide = 0;
            double thridSide = 10;
            // Act
            try
            {
                new Triangle(firstSide, secondSide, thridSide);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, Triangle.CannotCreateATriangleMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Triangle_IfThridSideIsZero_ShouldThrowException()
        {
            //Arrange
            double firstSide = 15;
            double secondSide = 18;
            double thridSide = 0;
            // Act
            try
            {
                new Triangle(firstSide, secondSide, thridSide);
            }
            catch (Exception e)
            {
                // Assert
                StringAssert.Contains(e.Message, Triangle.CannotCreateATriangleMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
