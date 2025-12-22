using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class LargeFactorial
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            BigInteger fact = 1;

            for (int i = 1; i <= n; i++)
                fact *= i;

            Console.WriteLine("Factorial = " + fact);
        }
    }
}
