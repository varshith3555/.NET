using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day08_
{
    struct Point
    {
        public int X;
        public int Y;

        public void Display()
        {
            Console.WriteLine($"X = {X}, Y = {Y}");
        }
    }

    class Program
    {
        static void Main()
        {
            Point p1 = new Point();
            p1.X = 10;
            p1.Y = 20;

            Point p2 = p1;   // copy by value
            p2.X = 50;

            p1.Display(); // X = 10, Y = 20
            p2.Display(); // X = 50, Y = 20
        }
    }
}
