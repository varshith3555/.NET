using System;

class InputHandler
{
    static void Main()
    {
        int number;
        bool isValid = false;

        while(!isValid)
        {
            Console.WriteLine("Enter a number:");
            try
            {
                number = int.Parse(Console.ReadLine()!);
                isValid = true;
                Console.WriteLine("Valid number entered: " + number);
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
