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
    public class PolynomialTests
    {
        [TestMethod]
        [ExpectedException(typeof(InitializationException),
            "List is empty.")]
        public void Polinomial_IfListIsEmpty_ShouldThrowInitialization()
        {
            //Arrange
            var list = new List<Monomial>();
            // Act
            var result = new Polynomial(list);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException),
            "Monomial can't be polynomial.")]
        public void Polinomial_IfListHasOneMonomial_ShouldThrowInitialization()
        {
            //Arrange
            var list = new List<Monomial>();
            var monomial = new Monomial(1, 5);
            list.Add(monomial);
            // Act
            var result = new Polynomial(list);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException),
            "There are few zero. Monomial can't be polynomial.")]
        public void Polinomial_IfListHasFewZeroAndOneNonZeroNumber_ShouldThrowInitialization()
        {
            //Arrange
            var firstMonomial = new Monomial(1, 5);
            var secondMonomial = new Monomial(3, 0);
            var thirdMonomial = new Monomial(2, 0);
            var list = new List<Monomial>() { firstMonomial, secondMonomial, thirdMonomial };
            // Act
            var result = new Polynomial(list);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException),
            "Array is empty.")]
        public void Polinomial_IfArrayIsEmpty_ShouldThrowInitialization()
        {
            //Arrange
            var array = new double[0];
            // Act
            var result = new Polynomial(array);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException),
            "Monomial can't be polynomial.")]
        public void Polinomial_IfArrayHasOneZero_ShouldThrowInitialization()
        {
            //Arrange
            var array = new double[] { 0 };
            // Act
            var result = new Polynomial(array);
        }

        [TestMethod]
        [ExpectedException(typeof(InitializationException),
            "There are few zero. Monomial can't be polynomial.")]
        public void Polinomial_IfArrayHasFewZeroAndOneNonZeroNumber_ShouldThrowInitialization()
        {
            //Arrange
            var array = new double[] { 0, 0, 5 }; 
            // Act
            var result = new Polynomial(array);
        }

        [TestMethod]
        public void Sum_IfAddFirstPolynomialToSecondPolynomial_ReturnsThridPolynomial()
        {
            // Arrange
            var firstPolynmial = new Polynomial(new double[] { 1, 3, 9 });
            var secondPolynomial = new Polynomial(new double[] { 6, 9 });
            var thridPolynomial = new Polynomial(new double[] { 7, 12, 9 });
            // Act
            var result = firstPolynmial + secondPolynomial;
            // Assert
            Assert.AreEqual(thridPolynomial, result);
        }

        [TestMethod]
        public void Difference_IfFromFirstPolynomialTakeSecondPolynomial_ReturnsThridPolynomial()
        {
            // Arrange
            var firstPolynmial = new Polynomial(new double[] { 1, 3, 9 });
            var secondPolynomial = new Polynomial(new double[] { 6, 9 });
            var thridPolynomial = new Polynomial(new double[] { -5, -6, 9 });
            // Act
            var result = firstPolynmial - secondPolynomial;
            // Assert
            Assert.AreEqual(thridPolynomial, result);
        }

        [TestMethod]
        public void Multiplication_IfPolynomialMultiplicateToMonomial_ReturnsThridPolynomial()
        {
            // Arrange
            var polynmial = new Polynomial(new double[] { 1, 3, 9 });
            var monomial = new Monomial(1, 6);
            var thridPolynomial = new Polynomial(new double[] { 0, 6, 18, 54 });
            // Act
            var result = polynmial * monomial;
            // Assert
            Assert.AreEqual(thridPolynomial, result);
        }

        [TestMethod]
        public void Sum_IfAddPolynomialToMonomial_ReturnsThridPolynomial()
        {
            // Arrange
            var polynmial = new Polynomial(new double[] { 1, 3, 9 });
            var monomial = new Monomial(3, 6);
            var thridPolynomial = new Polynomial(new double[] { 1, 3, 9, 6 });
            // Act
            var result = polynmial + monomial;
            // Assert
            Assert.AreEqual(thridPolynomial, result);
        }

        [TestMethod]
        public void Divide_IfDivideFirstPolynomialToSecondPolynomial_ReturnsThridPolynomial()
        {
            // Arrange
            var firstPolynmial = new Polynomial(new double[] { -3, -22, 23, -10, 2 });
            var secondPolynmial = new Polynomial(new double[] { 5, -3, 1 });
            var thridPolynomial = new Polynomial(new double[] { 1, -4, 2 });
            var resultRemainder = new Polynomial(new double[] { -8, 1 });
            // Act
            Polynomial remainder;
            var quotient = Polynomial.Divide(firstPolynmial, secondPolynmial, out remainder);
            // Assert
            Assert.AreEqual(thridPolynomial, quotient);
            Assert.AreEqual(resultRemainder, remainder);
        }


    }
}
