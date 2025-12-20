using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class PascalsTriangle
    {
        static void Main()
        {
            Console.Write("Enter number of rows: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = 1;

                for (int space = 0; space < n - i; space++)
                    Console.Write(" ");

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(number + " ");
                    number = number * (i - j) / (j + 1);
                }
                Console.WriteLine();
            }
        }
    }
}
