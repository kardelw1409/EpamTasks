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
            ConsoleKeyInfo keyInfo;
            IOutputPoint console = new ConsoleDisplay();
            FileInputPoint inputFromFile;
            Point point;
            Console.WriteLine("Press key 'X' to quit");
            using (inputFromFile = new FileInputPoint(args[0]))
            {
                while (true)
                {
                    keyInfo = Console.ReadKey(true);
                    // Exit if the user pressed the 'X' key.
                    if (keyInfo.Key == ConsoleKey.X) break;
                    point = inputFromFile.InputPoint();
                    if (point == null) break;
                    console.OutputPoint(point);
                }

            }
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
    }
}
