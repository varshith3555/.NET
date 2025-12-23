using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ValidDate
    {
        static void Main()
        {
            Console.Write("Enter day: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter month: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Enter year: ");
            int y = int.Parse(Console.ReadLine());

            bool leap = (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
            int[] days = { 31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (m >= 1 && m <= 12 && d >= 1 && d <= days[m - 1])
                Console.WriteLine("Valid Date");
            else
                Console.WriteLine("Invalid Date");
        }
    }
}
