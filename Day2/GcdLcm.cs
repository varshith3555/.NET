using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class GcdLcm
    {
        public static void Main()
        {
            Console.WriteLine("Enter first number:");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = int.Parse(Console.ReadLine());

            int gcd = 1;

            for (int i = 1; i <= a && i <= b; i++)
            {
                if (a % i == 0 && b % i == 0)
                {
                    gcd = i;
                }
            }

            int lcm = (a * b) / gcd;

            Console.WriteLine("GCD = " + gcd);
            Console.WriteLine("LCM = " + lcm);
        }
    }
}
