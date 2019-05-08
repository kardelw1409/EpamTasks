using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("1 Reading the coordinates from the console");
                Console.WriteLine("2 Reading the coordinates from the file");
                var input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        ReadPoinsFromConsole();
                        break;
                    case 2:
                        ReadPointsFromFile("coordinate.txt");
                        break;
                    default:
                        Console.WriteLine("Enter true number...");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter number!!!");
            }
            Console.ReadKey();
        }

        public static void ReadPoinsFromConsole()
        {
            Console.WriteLine("Please, enter points");
            try
            {
                var creator = new PointsCreator();
                var point = creator.CreatePoint(Console.ReadLine());
                Console.WriteLine($"X: {point.X} Y: {point.Y}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ReadPointsFromFile(string pathFile)
        {
            try
            {
                var inputFromFile = new PointsFromFileReader();
                var creator = new PointsCreator();
                var points = inputFromFile.GetPointsList(pathFile);
                foreach (var point in points)
                {
                    Console.WriteLine($"X: {point.X} Y: {point.Y}");
                }

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
