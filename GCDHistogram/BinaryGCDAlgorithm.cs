using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDHistogram
{
    /// <summary>
    /// This class contains the implementation of the binary Euclidean algorithm
    /// for finding greatest common divisor.
    /// </summary>
    public static class BinaryGCDAlgorithm
    {
        public const string ShouldBeSeveralParameters = "Should be several parameters";

        private static uint GetGreatestCommonDivisor(uint firstNumber, uint secondNumber)
        {
            // Simple cases (termination).
            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }
            if (firstNumber == 0)
            {
                return secondNumber;
            }
            if (secondNumber == 0)
            {
                return firstNumber;
            }
            if ((firstNumber == 1) || (secondNumber == 1))
            {
                return 1;
            }
            // Look for factors of 2.
            if ((firstNumber & 1) == 0) // firstNumber is even.
            {
                if ((secondNumber & 1) != 0) // secondNumber is odd.
                {
                    return GetGreatestCommonDivisor(firstNumber >> 1, secondNumber);
                }
                else // Both secondNumber and firstNumber are even.
                {
                    return GetGreatestCommonDivisor(firstNumber >> 1, secondNumber >> 1) << 1;
                }
            }
            if ((secondNumber & 1) == 0) // firstNumber is odd, secondNumber is even.
            {
                return GetGreatestCommonDivisor(firstNumber, secondNumber >> 1);
            }
            // Reduce larger argument.
            return firstNumber > secondNumber ? GetGreatestCommonDivisor((firstNumber - secondNumber) >> 1, secondNumber) :
                GetGreatestCommonDivisor((secondNumber - firstNumber) >> 1, firstNumber);
        }

        public static uint GetGreatestCommonDivisor(out double milliseconds, params uint[] numbers)
        {
            var watch = Stopwatch.StartNew();
            if (numbers.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Should be several parameters!");
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
