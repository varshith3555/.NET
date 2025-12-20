using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class GuessingGame
    {
        static void Main()
        {
            int secret = 7;
            int guess;

            do
            {
                Console.Write("Guess the number: ");
                guess = int.Parse(Console.ReadLine());

                if (guess != secret)
                    Console.WriteLine("Wrong guess, try again.");
            }
            while (guess != secret);

            Console.WriteLine("Correct! You guessed it.");
        }
    }
}
