using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class EvenOrOdd
    {
        public bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static void Main()
        {
            EvenOrOdd d2 = new EvenOrOdd();
            Console.WriteLine(d2.IsEven(7));
        }
    }
}
