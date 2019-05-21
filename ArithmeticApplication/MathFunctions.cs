using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticApplication
{
    public static class MathFunctions
    {
        /// <summary>
        /// The method is for counting a degree of number.
        /// </summary>
        /// <param name="number">Number to be raised to a degree. </param>
        /// <param name="degree">Degree of number.</param>
        /// <returns>Result.</returns>
        public static double Pow(double number, int degree)
        {
            double result = 1;
            if (degree == 0)
            {
                return result;
            }
            for (var count = 1; count <= degree; count++)
            {
                result = checked(result * number);
            }
            return degree > 0 ? result : 1.0 / result;
        }
        /// <summary>
        /// The method finds the number modulus.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>Result.</returns>
        public static double Abs(double number)
        {
            return number > 0 ? number : checked(-number);
        }
    }
}
