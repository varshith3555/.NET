using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class MenuSystem
    {
        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("\n1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Addition selected");
                        break;
                    case 2:
                        Console.WriteLine("Subtraction selected");
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            while (choice != 3);
        }
    }
}
