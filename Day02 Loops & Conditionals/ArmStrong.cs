using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ArmStrong
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number");
            int num = int.Parse(Console.ReadLine());

            int org = num;
            int sum = 0;
            int dig = 0;

            if (num == 0)
            {
                Console.WriteLine("Armstrong");
                return;
            }

            // Count digits
            int temp = num;
            while (temp > 0)
            {
                dig++;
                temp /= 10;
            }

            // Calculate Armstrong sum
            temp = num;
            while (temp > 0)
            {
                int digit = temp % 10;
                sum += (int)Math.Pow(digit, dig);
                temp /= 10;
            }

            // Compare
            Console.WriteLine(sum == org ? "Armstrong" : "Not Armstrong");
        }
    }
}
