using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    public class FileInputPoint : IDisposable
    {
        private StreamReader stream;
        
        public FileInputPoint(string path)
        {
            stream = new StreamReader(path);
        }

        public Point InputPoint()
        {
            var parser = new PointParser();
            string input;
            if ((input = stream.ReadLine()) != null)
            {
                return parser.InputPoint(input);
            }
            return null;
        }


        public void Dispose()
        {
            stream.Dispose();
        }

    }
}
