using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class LargeFactorial
    {
        static void Main()
        {
            Console.Write("Enter number: ");
            int n = int.Parse(Console.ReadLine());

            BigInteger fact = 1;

            for (int i = 1; i <= n; i++)
                fact *= i;

            Console.WriteLine("Factorial = " + fact);
        }
    }
}
