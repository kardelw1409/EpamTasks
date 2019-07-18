using System;
using System.Collections.Generic;
using System.Linq;

namespace GeometryProject
{
    public class Polynomial : IComparer<Monomial>, IEquatable<Polynomial>
    {
        public int NumberOfMonomial { get; private set; }
        public int DegreeOfPolynomial { get; private set; }
        public List<Monomial> MononmialList { get; private set; }

        /// <summary>
        /// Constructor that accepts a list of monomials. At the end of the list is sorted
        /// in ascending order of the degrees of the monomials.
        /// </summary>
        /// <param name="listOfMonomial">List of monomial</param>
        public Polynomial(List<Monomial> listOfMonomial)
        {
            MononmialList = new List<Monomial>();
            if (listOfMonomial.Count == 0)
            {
                throw new InitializationException("List is empty.");
            }
            if (listOfMonomial.Count == 1)
            {
                throw new InitializationException("Monomial can't be polynomial.");
            }
            DegreeOfPolynomial = listOfMonomial[0].Degree;
            foreach (var buffer in listOfMonomial)
            {
                if (buffer.Coefficient == 0)
                {
                    continue;
                }
                if (DegreeOfPolynomial < buffer.Degree)
                {
                    DegreeOfPolynomial = buffer.Degree;
                }
                MononmialList.Add(buffer);
            }
            if ((MononmialList.Count == 0) || (MononmialList.Count == 1))
            {
                throw new InitializationException("There are few zero. Monomial can't be polynomial.");
            }
            MononmialList.Sort();
            NumberOfMonomial = MononmialList.Count;
        }
        /// <summary>
        /// Constructor that takes an array of coefficients where the index is a degree of monomial.
        /// </summary>
        /// <param name="coefficients">Array of coefficients</param>
        public Polynomial(double[] coefficients)
        {
            if (coefficients.Length == 0)
            {
                throw new InitializationException("Array is empty.");
            }
            if (coefficients.Length == 1)
            {
                throw new InitializationException("Monomial can't be polynomial.");
            }
            MononmialList = new List<Monomial>();
            for (var i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] == 0)
                {
                    continue;
                }
                MononmialList.Add(new Monomial(i, coefficients[i]));
            }
            if ((MononmialList.Count == 0) || (MononmialList.Count == 1))
            {
                throw new InitializationException("There are few zero. Monomial can't be polynomial.");
            }
            DegreeOfPolynomial = MononmialList[MononmialList.Count - 1].Degree;
            MononmialList.Sort();
            NumberOfMonomial = MononmialList.Count;
        }
        /// <summary>
        /// Method used to calculate the sum and difference of polynomials.
        /// </summary>
        /// <param name="operation">Delegate of operation. Used sum or difference</param>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>Result polynomial</returns>
        private static Polynomial GetResultPolynomial(Func<double, double, double> operation,
            Polynomial first, Polynomial second)
        {
            if (first.DegreeOfPolynomial < second.DegreeOfPolynomial)
            {
                var buffer = first;
                first = second;
                second = buffer;
            }
            var firstArray = first.ToArrayCoefficients();
            var secondArray = second.ToArrayCoefficients();
            var listSumResult = firstArray.Zip(secondArray, operation).ToList();
            int lengthPartResult = firstArray.Length - secondArray.Length;
            if (lengthPartResult == 0)
            {
                return new Polynomial(listSumResult.ToArray());
            }
            else
            {
                double[] arrayEndPartResult = new double[lengthPartResult];
                Array.ConstrainedCopy(firstArray, secondArray.Length, arrayEndPartResult, 0, lengthPartResult);
                listSumResult.AddRange(arrayEndPartResult);
                return new Polynomial(listSumResult.ToArray());
            }
        }

        public static Polynomial operator + (Polynomial first, Polynomial second)
        {
            return GetResultPolynomial((x, y) => x + y, first, second);
        }

        public static Polynomial operator - (Polynomial first, Polynomial second)
        {
            return GetResultPolynomial((x, y) => x - y, first, second);
        }

        public static Polynomial operator * (Polynomial polynomial, Monomial monomial)
        {
            if (monomial.Coefficient == 0)
            {
                throw new ArithmeticException("Monomial can't be polynomial.");
            }
            var resultPolynomial = new List<Monomial>();
            foreach (var buffer in polynomial.MononmialList)
            {
                resultPolynomial.Add(new Monomial(buffer.Degree + monomial.Degree, buffer.Coefficient * monomial.Coefficient));
            }
            return new Polynomial(resultPolynomial);
        }

        public static Polynomial operator * (Monomial monomial, Polynomial polynomial)
        {
            return polynomial * monomial;
        }
       

        public static Polynomial operator + (Polynomial polynomial, Monomial monomial)
        {
            var resultList = new List<Monomial>(polynomial.MononmialList);
            foreach (var buffer in resultList.ToList())
            {
                if (buffer.Degree == monomial.Degree)
                {
                    var findedMonomialCoefficient = buffer.Coefficient;
                    resultList[resultList.FindIndex(i => i.Equals(buffer))] = new Monomial(monomial.Degree, findedMonomialCoefficient + monomial.Coefficient);
                    return new Polynomial(resultList);
                }
            }
            resultList.Add(monomial);
            return new Polynomial(resultList);
        }
        
        public static Polynomial operator + (Monomial monomial, Polynomial polynomial)
        {
            return polynomial + monomial;
        }

        public static Polynomial Divide(Polynomial polynomialFirst, Polynomial polynomialSecond, out Polynomial remainder)
        {
            if (polynomialSecond.DegreeOfPolynomial > polynomialFirst.DegreeOfPolynomial)
            {
                throw new ArgumentException("The degree of the divisor can't be greater than the degree of the divisible.");
            }
            remainder = polynomialFirst;
            Monomial monomialOfQuotient;
            var listResult = new List<Monomial>();
            var firstMemberDivisor = polynomialSecond.GetSeniorMember();
            do
            {
                var firstMemberFullPart = remainder.GetSeniorMember();
                monomialOfQuotient = firstMemberFullPart / firstMemberDivisor;
                var secondFull = polynomialSecond * monomialOfQuotient;
                remainder = remainder - secondFull;
                listResult.Add(monomialOfQuotient);
            }
            while (monomialOfQuotient.Degree != 0);
            return new Polynomial(listResult);
        }
        /// <summary>
        /// This method returns only quotient. To find the remainder, use the <see cref="Divide"/> method.
        /// </summary>
        /// <param name="polynomialFirst">First polynomial.</param>
        /// <param name="polynomialSecond">Second Polynomial.</param>
        /// <returns>Quotient polynomial</returns>
        public static Polynomial operator / (Polynomial polynomialFirst, Polynomial polynomialSecond)
        {
            Polynomial remainder;
            return Divide(polynomialFirst, polynomialSecond, out remainder);
        }

        /// <summary>
        /// The method convert Polynomial object to array.
        /// </summary>
        /// <returns>Result polynomial</returns>
        private double[] ToArrayCoefficients()
        {
            double[] arrayCoefficients = new double[MononmialList[MononmialList.Count - 1].Degree + 1];
            for (var i = 0; i < arrayCoefficients.Length; i++)
            {
                foreach (var buffer in MononmialList)
                {
                    if (i == buffer.Degree)
                    {
                        arrayCoefficients[i] = buffer.Coefficient;
                        break;
                    }
                }
            }
            return arrayCoefficients;
        }

        private Monomial GetSeniorMember()
        {
            return MononmialList.Find(i => i.Degree == DegreeOfPolynomial);
        }

        public int Compare(Monomial x, Monomial y)
        {
            return x.CompareTo(y);
        }

        public override string ToString()
        {
            var resultPolynomial = "";
            foreach (var buffer in MononmialList.Reverse<Monomial>())
            {
                resultPolynomial += buffer.ToString();
            }
            return resultPolynomial == "" ? "0" : resultPolynomial;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Polynomial)obj);
        }

        public bool Equals(Polynomial polynomial)
        {
            if (ReferenceEquals(null, polynomial))
            {
                return false;
            }
            if (ReferenceEquals(this, polynomial))
            {
                return true;
            }
            if (DegreeOfPolynomial != polynomial.DegreeOfPolynomial)
            {
                return false;
            }
            if (MononmialList.Count != polynomial.MononmialList.Count)
            {
                return false;
            }
            for (var i = 0; i < MononmialList.Count; i++)
            {
                if (MononmialList[i] != polynomial.MononmialList[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = 1205459986;
            hashCode = hashCode * -1521134295 + NumberOfMonomial.GetHashCode();
            hashCode = hashCode * -1521134295 + DegreeOfPolynomial.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Monomial>>.Default.GetHashCode(MononmialList);
            return hashCode;
        }
    }
}
