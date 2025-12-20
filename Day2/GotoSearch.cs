using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class GotoSearch
    {
        static void Main()
        {
            int[,] arr = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            int search = 5;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == search)
                    {
                        Console.WriteLine("Found at position [" + i + "," + j + "]");
                        goto Found;
                    }
                }
            }

            Console.WriteLine("Not Found");

        Found:
            Console.WriteLine("Search Completed");
        }
    }
}
