using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ProfitLoss
    {
        static void Main()
        {
            Console.Write("Enter Cost Price: ");
            double cp = double.Parse(Console.ReadLine());
            Console.Write("Enter Selling Price: ");
            double sp = double.Parse(Console.ReadLine());

            if (sp > cp)
                Console.WriteLine("Profit % = " + ((sp - cp) / cp) * 100);
            else if (cp > sp)
                Console.WriteLine("Loss % = " + ((cp - sp) / cp) * 100);
            else
                Console.WriteLine("No Profit No Loss");
        }
    }
}
