using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    public class PointsFromFile
    {
        public List<Point> GetListPoints(string path)
        {
            var creator = new PointCreator();
            var list = new List<Point>();
            string input;
            try
            {
                using (var stream = new StreamReader(path))
                {
                    while ((input = stream.ReadLine()) != null)
                    {
                        list.Add(creator.CreatePoint(input));
                    }
                }

            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException("Invalid path", ae);
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
