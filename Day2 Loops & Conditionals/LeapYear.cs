using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class LeapYear
    {
        public static void Main()
        {
            Console.WriteLine("Enter the year");
            /// int year = int.Parse(Console.ReadLine());
            ///  Or 
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            if (year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
            {
                Console.WriteLine("leap year");
            }
            else
            {
                Console.WriteLine("Not leap year");
            }
        }
    }
}
