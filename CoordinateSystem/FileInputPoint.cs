using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    class FileInputPoint : IInputPoint, IDisposable
    {
        private StreamReader stream;
        
        public FileInputPoint(string path)
        {
            stream = new StreamReader(path);
        }

        public Point InputPoint()
        {
            Point point;
            string input;
            string[] numbersLine;
            double x;
            double y;
            if ((input = stream.ReadLine()) != null)
            {
                numbersLine = input.Split(',');
                x = double.Parse(numbersLine[0], CultureInfo.InvariantCulture);
                y = double.Parse(numbersLine[1], CultureInfo.InvariantCulture);
                point = new Point(x, y);
                return point;
            }
            return null;
        }


        public void Dispose()
        {
            stream.Dispose();
        }

    }
}
