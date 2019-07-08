using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                /*Console.WriteLine("Enter three side of triangle");
                var firstSide = double.Parse(Console.ReadLine());
                var secondSide = double.Parse(Console.ReadLine());
                var thirdSide = double.Parse(Console.ReadLine());
                var triangle = new Triangle(firstSide, secondSide, thirdSide);
                Console.WriteLine("Area : " + triangle.GetArea());
                Console.WriteLine("Perimeter : " + triangle.GetPerimeter());*/
                Console.WriteLine("Polynomial operation");
                var firstArrayCoefficients = new double[] { -3, -22, 23, -10, 2 };
                var secondArrayCoefficients = new double[] { 5, -3, 1 };
                var firstPolynomial = new Polynomial(firstArrayCoefficients);
                Console.WriteLine("First Polynomial " + firstPolynomial.ToString());
                var secondPolynomial = new Polynomial(secondArrayCoefficients);
                Console.WriteLine("Second Polynomial " + secondPolynomial.ToString());
                Polynomial remainder;
                var quotient = Polynomial.Division(firstPolynomial, secondPolynomial, out remainder);
                Console.WriteLine("Quotient : ");
                Console.WriteLine(quotient.ToString());
                Console.WriteLine("Remainder : ");
                Console.WriteLine(remainder.ToString());
                Console.WriteLine("===========================");
                Console.WriteLine("Vector operation");
                var firstVector = new Vector(2, 2, 0);
                var secondVector = new Vector(3, -1, 0);
                Console.WriteLine("Angle between vectors " + firstVector.ToString() + " and " + secondVector.ToString());
                Console.WriteLine(Vector.GetAngleBetweenVectors(firstVector, secondVector));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
