using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class ATM
    {
        static void Main()
        {
            Console.Write("Insert card (1=Yes): ");
            int card = int.Parse(Console.ReadLine());

            if (card == 1)
            {
                Console.Write("Enter PIN: ");
                int pin = int.Parse(Console.ReadLine());

                if (pin == 1234)
                {
                    int balance = 5000;
                    Console.Write("Enter amount: ");
                    int amt = int.Parse(Console.ReadLine());

                    if (amt <= balance)
                        Console.WriteLine("Withdrawal Successful");
                    else
                        Console.WriteLine("Insufficient Balance");
                }
                else
                    Console.WriteLine("Invalid PIN");
            }
            else
                Console.WriteLine("Card Not Inserted");
        }
    }
}
