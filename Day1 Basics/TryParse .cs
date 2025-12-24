using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day1
{
    public class TryParse
    {
        public static void Main()
        {
            //TryParse 
            Console.Write("Enter age: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int age))
            {
                bool isAdult = age >= 18;
                Console.WriteLine("Adult? " + isAdult);
            }
            else
            {
                Console.WriteLine("Invalid age. Please enter a whole number.");
            }
        }
    }
}
