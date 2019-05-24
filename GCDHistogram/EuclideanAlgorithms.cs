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
    /// and the binary Euclidean algorithm for finding GCD.
    /// </summary>
    public static class EuclideanAlgorithms
    {
        private static uint CalculateBinaryGCD(uint firstNumber, uint secondNumber)
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
            // Look for factors of 2.
            if ((firstNumber & 1) == 0) // firstNumber is even.
            {
                if ((secondNumber & 1) != 0) // secondNumber is odd.
                {
                    return CalculateBinaryGCD(firstNumber >> 1, secondNumber);
                }
                else // Both u and v are even.
                {
                    return CalculateBinaryGCD(firstNumber >> 1, secondNumber >> 1) << 1;
                }
            }
            if (secondNumber % 2 == 0) // secondNumber is odd, v is even.
            {
                return CalculateBinaryGCD(firstNumber, secondNumber >> 1);
            }
            // Reduce larger argument.
            return firstNumber > secondNumber ? CalculateBinaryGCD((firstNumber - secondNumber) >> 1, secondNumber) :
                CalculateBinaryGCD((secondNumber - firstNumber) >> 1, firstNumber);
        }

        private static uint CalculateGCD(uint firstNumber, uint secondNumber)
        {
            if (firstNumber == 0 || secondNumber == 0)
            {
                throw new ArithmeticException("The number should be non zero");
            }
            while (secondNumber != 0)
            {
                var buffer = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = buffer;
            }
            return firstNumber;
        }

        public static uint CalculateGCDOfBinary(out double milliseconds, params uint[] numbers)
        {
            var watch = Stopwatch.StartNew();
            if (numbers.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Should be several parameters!");
            }
            var result = CalculateBinaryGCD(numbers[0], numbers[1]);
            for (var i = 2; i < numbers.Length; i++)
            {
                result = CalculateBinaryGCD(result, numbers[i]);
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            milliseconds = ts.TotalMilliseconds;
            return result;
        }

        public static uint CalculateGCD(out double milliseconds, params uint[] numbers)
        {
            var watch = Stopwatch.StartNew();
            if (numbers.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Should be several parameters!");
            }
            var result = CalculateGCD(numbers[0], numbers[1]);
            for (var i = 2; i < numbers.Length; i++)
            {
                result = CalculateGCD(result, numbers[i]);
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;
            milliseconds = ts.TotalMilliseconds;
            return result;
        }
    }
}
