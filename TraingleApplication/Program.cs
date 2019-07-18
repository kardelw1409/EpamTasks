using System;

namespace TraingleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter three side of triangle");
            var firstSide = double.Parse(Console.ReadLine());
            var secondSide = double.Parse(Console.ReadLine());
            var thirdSide = double.Parse(Console.ReadLine());
            var triangle = new Triangle(firstSide, secondSide, thirdSide);
            Console.WriteLine("Area : " + triangle.GetArea());
            Console.WriteLine("Perimeter : " + triangle.GetPerimeter());
        }
    }
}
