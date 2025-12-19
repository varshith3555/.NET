using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class Height
    {
        public static void Main()
        {
            /// Check the Height
            Console.WriteLine("Enter height:");
            int height = int.Parse(Console.ReadLine());

            if (height < 150)
            {
                Console.WriteLine("Dwarf");
            }
            else if (height >= 150 && height < 165)
            {
                Console.WriteLine("Adult");
            }
            else if (height >= 165 && height < 190)
            {
                Console.WriteLine("Tall");
            }
            else
            {
                Console.WriteLine("Abnormal");
            }
        }
    }
}
