using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    public class PointsCreator
    {
        public Point CreatePoint(string inputString)
        {
            double x, y;
            try
            {
                var input = inputString.Split(',');
                if (input.Length != 2)
                {
                    throw new FormatException();
                }
                x = double.Parse(input[0], CultureInfo.InvariantCulture);
                y = double.Parse(input[1], CultureInfo.InvariantCulture);
            }
            catch (FormatException fe)
            {
                throw new FormatException("Invalid format", fe);
            }
            catch (Exception)
            {
                throw;
            }
            return new Point(x, y);
        }
    }
}
