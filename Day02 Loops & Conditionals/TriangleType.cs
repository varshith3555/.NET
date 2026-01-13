using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class TriangleType
    {
        static void Main()
        {
            Console.Write("Enter side 1: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter side 2: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter side 3: ");
            int c = int.Parse(Console.ReadLine());

            if (a == b && b == c)
                Console.WriteLine("Equilateral Triangle");
            else if (a == b || b == c || a == c)
                Console.WriteLine("Isosceles Triangle");
            else
                Console.WriteLine("Scalene Triangle");
        }
    }
}
