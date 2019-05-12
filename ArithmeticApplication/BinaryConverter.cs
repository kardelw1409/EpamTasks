using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticApplication
{
    public static class BinaryConverter
    {
        public static string ToString(int number)
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

        /*public static string ToStringv2(int number)
        {
            if (number < 0)
            {
                throw new ArithmeticException("The number should be non-negative");
            }
            return Convert.ToString(number, 2);
        }*/

    }
}
