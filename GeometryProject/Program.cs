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
                Console.WriteLine("Enter three side of triangle");
                var firstSide = double.Parse(Console.ReadLine());
                var secondSide = double.Parse(Console.ReadLine());
                var thirdSide = double.Parse(Console.ReadLine());
                var triangle = new Triangle(firstSide, secondSide, thirdSide);
                Console.WriteLine("Area : " + triangle.GetArea());
                Console.WriteLine("Perimeter : " + triangle.GetPerimeter());
                var a = new double[] { -6.0, -6.0, -10.0, 10.2 };
                var p = new Polynomial(a);
                var p2 = new Monomial(3, -5.5);
                var r = p + p2;
                Console.WriteLine(r.ToString());
                //Console.WriteLine(Vector.GetAngleBetweenVectors(new Vector(2,2,0), new Vector(3,-1,0)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
