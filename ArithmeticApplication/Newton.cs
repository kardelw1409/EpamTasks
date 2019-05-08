using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticApplication
{
    public static class Newton
    {
        /// <summary>
        /// The method calculates the root of degree from number with a given accuracy.
        /// Newton's method is used here.
        /// </summary>
        /// <param name="number">Number under the root.</param>
        /// <param name="degree">Root of degree.</param>
        /// <param name="accuracy">Accuracy for algorithm.</param>
        /// <returns>Counted number</returns>
        public static double Sqrt(double number, int degree, double accuracy)
        {
            int negativeDegree = 0;
            if (number < 0)
            {
                return double.NaN;
            }
            if (((number == 0) && (degree == 0)) || (number == 0))
            {
                return 0;
            }
            if (degree == 0)
            {
                return double.PositiveInfinity;
            }
            if (degree < 0)
            {
                negativeDegree = degree;
                degree = (int)MathFunctions.Abs(degree);
            }
            double result;
            double guess = 1 + (number - 1) / degree;
            while (true)
            {
                guess = guess - ((MathFunctions.Pow(guess, degree) - number) / 
                    (degree * MathFunctions.Pow(guess, degree - 1)));
                if (MathFunctions.Abs(number - MathFunctions.Pow(guess, degree)) <= accuracy)
                {
                    result = guess;
                    break;
                }
            }
            if (negativeDegree < 0)
            {
                return 1 / result;
            }
            return result;
        }
    }
}
