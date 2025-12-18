// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter name:");
        string? name = Console.ReadLine();
        Console.WriteLine("Hello, " + name + "!");

        // Call practice files directly
        Day1Practise.Run();        
    }
}

