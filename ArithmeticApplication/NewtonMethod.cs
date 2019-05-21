using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ArithmeticApplication.MathFunctions;

namespace ArithmeticApplication
{
    public static class NewtonMethod
    {
        /// <summary>
        /// The method calculates the root of degree from number with a given accuracy.
        /// Newton's method is used here.
        /// </summary>
        /// <param name="number">Number under the root.</param>
        /// <param name="degree">Root of degree.</param>
        /// <param name="accuracy">Accuracy for algorithm.</param>
        /// <returns>Counted number</returns>
        public static double CalculateRoot(double number, int degree, double accuracy)
        {
            if (number < 0)
            {
                return double.NaN;
            }
            if (number == 1)
            {
                return 1;
            }
            if ((number == 0) && (degree >= 0))
            {
                return 0;
            }
            if ((number == 0) && (degree < 0))
            {
                return double.PositiveInfinity;
            }
            if (degree == 0)
            {
                return double.PositiveInfinity;
            }
            var negativeDegree = false;
            if (degree < 0)
            {
                negativeDegree = true;
                degree = (int)Abs(degree);
            }
            double approximation = 1 + (number - 1) / degree;
            double difference;
            do
            {
                var valueOfFunctin = Pow(approximation, degree) - number;
                var derivativeOfFunction = degree * Pow(approximation, degree - 1);
                approximation = approximation - valueOfFunctin / derivativeOfFunction;
                difference = Abs(number - Pow(approximation, degree));
            } while (difference > accuracy);

            return negativeDegree ? 1.0 / approximation : approximation;
        }
    }
}
