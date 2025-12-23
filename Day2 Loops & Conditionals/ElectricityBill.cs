using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ElectricityBill
    {
        static void Main()
        {
            Console.Write("Enter units: ");
            int units = int.Parse(Console.ReadLine());
            double bill = 0;

            if (units <= 199)
                bill = units * 1.20;
            else if (units <= 399)
                bill = 199 * 1.20 + (units - 199) * 1.50;
            else if (units <= 599)
                bill = 199 * 1.20 + 200 * 1.50 + (units - 399) * 1.80;
            else
                bill = 199 * 1.20 + 200 * 1.50 + 200 * 1.80 + (units - 599) * 2.00;

            if (bill > 400)
                bill += bill * 0.15;

            Console.WriteLine("Total Bill = " + bill);
        }
    }
}
