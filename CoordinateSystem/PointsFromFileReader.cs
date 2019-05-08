using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    public class PointsFromFileReader
    {
        public List<Point> GetPointsList(string path)
        {
            var pointsCreator = new PointsCreator();
            var pointsList = new List<Point>();
            string input;
            try
            {
                using (var stream = new StreamReader(path))
                {
                    while ((input = stream.ReadLine()) != null)
                    {
                        pointsList.Add(pointsCreator.CreatePoint(input));
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
            return pointsList;
        }
    }
}
