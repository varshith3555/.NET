using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class PrimeNumber
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number");
            int n = int.Parse(Console.ReadLine());

            bool Prime = true;

            if (n <= 1) Prime = false;

            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    Prime = false;
                    break;
                }
            }
            Console.WriteLine(Prime ? "Prime" : "Not Prime");
        }
    }
}
