using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ContinueExample
    {
        static void Main()
        {
            for (int i = 1; i <= 50; i++)
            {
                if (i % 3 == 0)
                    continue;

                Console.Write(i + " ");
            }
        }
    }
}
