using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            { 
                CalculateRootOfNumber();
                FindBinaryNumber();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static void CalculateRootOfNumber()
        {
            Console.WriteLine("-----------Calculate Root Of Number---------");
            Console.WriteLine("Enter number...");
            var number = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter degree...");
            var degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter accuracy...");
            var accuracy = double.Parse(Console.ReadLine());
            Console.WriteLine("Result from my function : " + NewtonMethod.CalculateRoot(number, degree, accuracy));
            Console.WriteLine("Result from Math.Pow() : " + Math.Pow(number, 1.0 / degree));
        }

        static void FindBinaryNumber()
        {
            Console.WriteLine("---------Search binary number------------");
            Console.WriteLine("Enter integer non-negative number...");
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine("Binary result : " + BinaryConverter.GetBinary(number));
        }
    }
}
