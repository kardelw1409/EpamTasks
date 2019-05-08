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
                Console.WriteLine("First Task");
                Console.WriteLine("Enter number...");
                var number = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter degree...");
                var degree = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter accuracy...");
                var accuracy = double.Parse(Console.ReadLine());
                Console.WriteLine("Result from my function : " + Newton.Sqrt(number, degree, accuracy));
                Console.WriteLine("Result from Math.Pow() : " + Math.Pow(number, 1.0 / degree));
                Console.WriteLine("Second Task");
                Console.WriteLine("Enter integer non-negative number...");
                Console.WriteLine("Binary result : " + BinaryConverter.ToStringv2(int.Parse(Console.ReadLine())));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
