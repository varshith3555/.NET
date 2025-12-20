using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class StrongNumber
    {
        static int Factorial(int n)
        {
            int fact = 1;
            for (int i = 1; i <= n; i++)
                fact *= i;
            return fact;
        }

        static void Main()
        {
            Console.Write("Enter number: ");
            int num = int.Parse(Console.ReadLine());
            int temp = num, sum = 0;

            while (temp > 0)
            {
                int digit = temp % 10;
                sum += Factorial(digit);
                temp /= 10;
            }

            if (sum == num)
                Console.WriteLine("Strong Number");
            else
                Console.WriteLine("Not a Strong Number");
        }
    }
}
