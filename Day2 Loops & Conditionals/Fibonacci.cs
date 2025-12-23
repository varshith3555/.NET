using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class Fibonacci
    {
        public static void Main()
        {
            /// first N terms of the Fibonacci sequence.
            Console.WriteLine("Enter the number");
            int n = int.Parse(Console.ReadLine());

            int a = 0, b = 1;
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(a);
                int c = a + b;
                a = b;
                b = c;
            }
        }
    }
}
