using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDHistogram
{
    /// <summary>
    /// This class contains the implementation of the Euclidean algorithm
    /// for finding greatest common divisor.
    /// </summary>
    public static class EuclideanAlgorithm
    {
        public const string TheNumberShouldBeNonZeroMessage = "The number should be non zero";
        public const string ShouldBeSeveralParameters = "Should be several parameters";

        private static uint GetGreatestCommonDivisor(uint firstNumber, uint secondNumber)
        {
            if (firstNumber == 0 || secondNumber == 0)
            {
                throw new ArithmeticException(TheNumberShouldBeNonZeroMessage);
            }
            while (secondNumber != 0)
            {
                var buffer = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = buffer;
            }
            return firstNumber;
        }

        public static uint GetGreatestCommonDivisor(out double milliseconds, params uint[] numbers)
        {
            var watch = Stopwatch.StartNew();
            if (numbers.Length < 2)
            {
                throw new ArgumentOutOfRangeException(ShouldBeSeveralParameters);
            }
            var result = GetGreatestCommonDivisor(numbers[0], numbers[1]);
            for (var i = 2; i < numbers.Length; i++)
            {
                result = GetGreatestCommonDivisor(result, numbers[i]);
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            milliseconds = ts.TotalMilliseconds;
            return result;
        }
    }
}
