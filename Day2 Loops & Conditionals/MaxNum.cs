using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day2
{
    internal class MaxNum
    {
        public static void Main()
        {
            /// input reading
            Console.WriteLine("Enter three numbers");
            int a1 = int.Parse(Console.ReadLine());
            int a2 = int.Parse(Console.ReadLine());
            int a3 = int.Parse(Console.ReadLine());

            /// finding maximum
            if (a1 > a2)
            {
                if (a1 > a3)
                {
                    Console.WriteLine("a1 is greater");
                }
                else
                {
                    Console.WriteLine("a3 is greater");
                }
            }
            else
            {
                if (a2 > a3)
                {
                    Console.WriteLine("a2 is greater ");
                }
                else
                {
                    Console.WriteLine("a3 is greater");
                }
            }
        }
    }
}
