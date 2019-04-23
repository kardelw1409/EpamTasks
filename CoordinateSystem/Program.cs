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
            Console.WriteLine("Press key 'X' to quit");
            while (true)
            {
                keyInfo = Console.ReadKey(true);
                // Exit if the user pressed the 'X' key.
                if (keyInfo.Key == ConsoleKey.X) break;
                var console = new ConsoleDisplay();
                console.OutputPoint(console.InputPoint());
            }

        }
    }
}
