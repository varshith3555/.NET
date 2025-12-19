using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ReversePalindrome
    {
        public static void Main()
        {
            Console.WriteLine("Enter a number:");
            int number = int.Parse(Console.ReadLine());

            int original = number;
            int reverse = 0;

            // Reverse the number using while loop
            while (number > 0)
            {
                int digit = number % 10;
                reverse = reverse * 10 + digit;
                number /= 10;
            }

            Console.WriteLine("Reversed number: " + reverse);

            // Palindrome check
            if (reverse == original)
                Console.WriteLine("Palindrome Number");
            else
                Console.WriteLine("Not a Palindrome Number");
        }
    }
}
