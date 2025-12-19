using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class AdmissionEligibility
    {
        public static void Main()
        {
            Console.WriteLine("Enter marks in Mathematics:");
            int math = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter marks in Physics:");
            int phys = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter marks in Chemistry:");
            int chem = int.Parse(Console.ReadLine());

            int total = math + phys + chem;

            if (math >= 65 && phys >= 55 && chem >= 50 &&
                (total >= 180 || (math + phys) >= 140))
            {
                Console.WriteLine("Eligible for Admission");
            }
            else
            {
                Console.WriteLine("Not Eligible for Admission");
            }
        }
    }
}
