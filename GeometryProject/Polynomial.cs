using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    public class Polynomial
    {
        public int DegreeOfPolynomial { get; private set; }
        public List<Monomial> MononmialList { get; private set; }

        public Polynomial(List<Monomial> listPolynomial)
        {
            if (listPolynomial.Count == 1)
            {
                throw new ArithmeticException("Monomial can't be polynomial");
            }
            DegreeOfPolynomial = listPolynomial[0].Degree;
            foreach (var buffer in listPolynomial)
            {
                if (DegreeOfPolynomial < buffer.Degree)
                {
                    DegreeOfPolynomial = buffer.Degree;
                }
                MononmialList.Add(buffer);
            }
        }

        public Polynomial(double[] coefficients)
        {
            if (coefficients.Length == 1)
            {
                throw new ArithmeticException("Monomial can't be polynomial");
            }
            MononmialList = new List<Monomial>();
            for (var i = 0; i < coefficients.Length; i++)
            {
                MononmialList.Add(new Monomial(i, coefficients[i]));
            }
            DegreeOfPolynomial = coefficients.Length - 1;
        }

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

        /*public static Polynomial operator * (Polynomial polynomial, Monomial monomial)
        {
            var resultPolynomial = new Polynomial();
            for (var i = 0; i < arrayPolynomial.Length; i++)
            {

            }
            return ;
        }
        */

        public static Polynomial operator + (Polynomial polynomial, Monomial monomial)
        {
            var resultList = new List<Monomial>(polynomial.MononmialList);
            foreach (var buffer in resultList)
            {
                if (buffer.Degree == monomial.Degree)
                {
                    resultList[resultList.FindIndex(i => i.Equals(buffer))] = new Monomial(monomial.Degree, buffer.Coefficient);

                }
            }
            resultList.Add(monomial);
            return new Polynomial(resultList);
        } 

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

        public override string ToString()
        {
            var resultPolynomial = "";
            foreach (var buffer in MononmialList)
            {
                resultPolynomial += buffer.ToString();
            }
            return resultPolynomial == "" ? "0" : resultPolynomial;
        }
    }
}
