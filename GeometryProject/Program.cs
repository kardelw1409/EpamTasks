using System;

namespace GeometryProject
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Polynomial operation");
                var firstArrayCoefficients = new double[] { -3, -22, 23, -10, 2 };
                var firstPolynomial = new Polynomial(firstArrayCoefficients);
                Console.WriteLine("First Polynomial " + firstPolynomial.ToString());

                var secondArrayCoefficients = new double[] { 5, -3, 1 };
                var secondPolynomial = new Polynomial(secondArrayCoefficients);
                Console.WriteLine("Second Polynomial " + secondPolynomial.ToString());

                Console.WriteLine("Division");
                Polynomial remainder;
                var quotient = Polynomial.Divide(firstPolynomial, secondPolynomial, out remainder);
                Console.WriteLine("Quotient : ");
                Console.WriteLine(quotient.ToString());
                
                Console.WriteLine("Remainder : ");
                Console.WriteLine(remainder.ToString());

                Console.WriteLine("Sum");
                var sum = firstPolynomial + secondPolynomial;
                Console.WriteLine(sum.ToString());

                Console.WriteLine("Difference");
                var difference = firstPolynomial - secondPolynomial;
                Console.WriteLine(difference.ToString());

                Console.WriteLine("===========================");

                Console.WriteLine("Vector operation");
                var firstVector = new Vector(2, 2, 0);
                var secondVector = new Vector(3, -1, 0);
                Console.WriteLine("First vector " + firstVector.ToString());
                Console.WriteLine("Second vector" + secondVector.ToString());

                Console.WriteLine("Sum");
                Console.WriteLine((firstVector + secondVector).ToString());

                Console.WriteLine("Difference");
                Console.WriteLine((firstVector - secondVector).ToString());

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
