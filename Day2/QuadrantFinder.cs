using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class QuadrantFinder
    {
        static void Main()
        {
            Console.Write("Enter x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter y: ");
            int y = int.Parse(Console.ReadLine());

            if (x > 0 && y > 0)
                Console.WriteLine("1st Quadrant");
            else if (x < 0 && y > 0)
                Console.WriteLine("2nd Quadrant");
            else if (x < 0 && y < 0)
                Console.WriteLine("3rd Quadrant");
            else if (x > 0 && y < 0)
                Console.WriteLine("4th Quadrant");
            else
                Console.WriteLine("On Axis");
        }
    }
}
