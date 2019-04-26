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
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("1 Reading the coordinates from the console");
                Console.WriteLine("2 Reading the coordinates from the file");
                Console.WriteLine("3 Clear window");
                Console.WriteLine("4 Exit");
                var input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        ReadPoinsFromConsole();
                        break;
                    case 2:
                        ReadPointsFromFile("coordinate.txt");
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Enter true namber...");
                        break;
                }
            }
        }

        public static void ReadPoinsFromConsole()
        {
            Console.WriteLine("Press only 'Enter' to return in a menu");
            Console.WriteLine("Please, enter points");
            try
            {
                while (true)
                {
                    var creator = new PointCreator();
                    var consoleInput = Console.ReadLine();
                    if (consoleInput.Length == 0)
                    {
                        break;
                    }
                    var point = creator.CreatePoint(consoleInput);
                    Console.WriteLine($"X: {point.X} Y: {point.Y}");
                }
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
                var inputFromFile = new PointsFromFile();
                var creator = new PointCreator();
                var points = inputFromFile.GetListPoints(pathFile);
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
