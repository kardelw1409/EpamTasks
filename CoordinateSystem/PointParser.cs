using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    public class PointParser
    {
        public Point InputPoint(string inputString)
        {
            Point point;
            string[] input = inputString.Split(',');
            if (input.Length != 2) { throw new Exception("Неверное число параметров"); }
            double x = double.Parse(input[0], CultureInfo.InvariantCulture);
            double y = double.Parse(input[1], CultureInfo.InvariantCulture);
            point = new Point(x, y);
            return point;
        }

        public string OutputPoint(Point point)
        {
            return string.Format($"X: {point.X} Y: {point.Y}");
        }
    }
}
