using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    class ConsoleDisplay : IOutputPoint, IInputPoint
    {
        public Point InputPoint()
        {
            Point point;
            string[] input = Console.ReadLine().Split(',');
            double x = double.Parse(input[0], CultureInfo.InvariantCulture);
            double y = double.Parse(input[1], CultureInfo.InvariantCulture);
            point = new Point(x, y);
            return point;
        }

        public void OutputPoint(Point point)
        {
            Console.WriteLine($"X: {point.X} Y: {point.Y}");
        }
    }
}
