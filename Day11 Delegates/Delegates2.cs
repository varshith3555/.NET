using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day11
{
    public delegate string PrintMessage(string message);
    public class PrintCompany
    {
        public PrintMessage CustomerChoice { get; set; }
        public void Print(string message)
        {
            string messageToPrint = CustomerChoice(message);
            Console.WriteLine(messageToPrint);
        }

        static void Main()
        {
            PrintCompany p = new PrintCompany();
            p.CustomerChoice = new PrintMessage(Method1);

            p.Print("Ram");


            Console.ReadLine();
        }

        private static string Method1(string message)
        {
            return "Welcome " + message;
        }
    }
}
