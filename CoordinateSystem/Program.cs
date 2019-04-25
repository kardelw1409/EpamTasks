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
            var console = new ConsoleDisplay();
            FileInputPoint inputFromFile;
            Point point;
            Console.WriteLine("Press key 'X' to quit");
            if (args.Length == 0)
            {
                while (true)
                {
                    keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.X) break;
                    point = console.InputPoint();
                    if (point == null) break;
                    console.OutputPoint(point);
                }
            }
            else
            {
                using (inputFromFile = new FileInputPoint(args[0]))
                {
                    while (true)
                    {
                        point = inputFromFile.InputPoint();
                        if (point == null) break;
                        console.OutputPoint(point);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
