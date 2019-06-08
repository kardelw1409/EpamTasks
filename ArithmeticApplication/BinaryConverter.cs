using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticApplication
{
    public static class BinaryConverter
    {
        public static string GetBinary(int number)
        {
            string result = "";
            if (number < 0)
            {
                throw new ArithmeticException("The number should be non-negative");
            }
            var buffer = number;
            while(buffer > 1)
            {
                result = (buffer % 2) + result;
                buffer = buffer / 2;
            }
            result = (buffer % 2) + result;
            return result;
        }

    }
}
