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
        public Dictionary<int, Monomial> MononmialDictonary { get; private set; }

        /*public Polynomial(int degree)
        {
            Coefficients = new double[degree];
        }*/

        public Polynomial(double[] coefficients)
        {
            MononmialDictonary = new Dictionary<int, Monomial>();
            for (var i = 0; i < coefficients.Length; i++)
            {
                MononmialDictonary.Add(i, new Monomial(i, coefficients[i]));
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

        private double[] ToArrayCoefficients()
        {
            double[] arrayCoefficients = new double[MononmialDictonary[MononmialDictonary.Count - 1].Degree + 1];
            for (var i = 0; i < arrayCoefficients.Length; i++)
            {
                arrayCoefficients[i] = MononmialDictonary.FirstOrDefault(x => x.Key == i).Value.Coefficient;
            }
            return arrayCoefficients;
        }

        public override string ToString()
        {
            var resultPolynomial = "";
            foreach (var buffer in MononmialDictonary)
            {
                resultPolynomial += buffer.Value.ToString();
            }
            return resultPolynomial == "" ? "0" : resultPolynomial;
        }
    }
}
