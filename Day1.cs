using System;

class Day1Practise
{
    public static void Run()
    {
        //TryParse 
        Console.WriteLine("Enter age:");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            Console.WriteLine(age >= 18 ? "Adult" : "Not Adult");
        }
        else
        {
            Console.WriteLine("Invalid input");
        }
    }
}
