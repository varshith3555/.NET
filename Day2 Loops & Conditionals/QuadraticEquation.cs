using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class QuadraticEquation
    {
        static void Main()
        {
            double a, b, c;
            double discriminant, root1, root2;

            Console.Write("Enter value of a: ");
            a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter value of b: ");
            b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter value of c: ");
            c = Convert.ToDouble(Console.ReadLine());

            // Calculate discriminant
            discriminant = b * b - 4 * a * c;

            // Check discriminant
            if (discriminant > 0)
            {
                root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("Roots are real and different:");
                Console.WriteLine("Root 1 = " + root1);
                Console.WriteLine("Root 2 = " + root2);
            }
            else if (discriminant == 0)
            {
                root1 = -b / (2 * a);
                Console.WriteLine("Roots are real and equal:");
                Console.WriteLine("Root = " + root1);
            }
            else
            {
                Console.WriteLine("Roots are imaginary (no real roots).");
            }
        }
    }
}
