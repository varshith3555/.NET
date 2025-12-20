using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class DigitalRoot
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());

            while (num >= 10)
            {
                int sum = 0;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }
                num = sum;
            }

            Console.WriteLine("Single Digit Result = " + num);
        }
    }
}
