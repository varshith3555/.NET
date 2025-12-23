using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class BinaryToDecimal
    {
        static void Main()
        {
            Console.Write("Enter binary number: ");
            string binary = Console.ReadLine();
            int decimalValue = 0, baseVal = 1;

            for (int i = binary.Length - 1; i >= 0; i--)
            {
                if (binary[i] == '1')
                    decimalValue += baseVal;

                baseVal *= 2;
            }

            Console.WriteLine("Decimal = " + decimalValue);
        }
    }
}
