using MyConsoleApp.Day4;
using MyConsoleApp.Day9;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MyConsoleApp.Day13_LINQ
{
    public class Linq
    {
        static void Main()
        {
            string[] names = { "AbA", "Bab", "CCC", "DA", };
            ///This is normal method to print the values
            //foreach (var item in names)
            //{
            //    if (item == "A")
            //    {
            //        Console.WriteLine("A is present");
            //    }
            //}

            /// Or using LINQ with below syntax
            //var findName = from name in names
            //               where name == "A"
            //               select name;
            //if (findName != null)
            //{
            //    Console.WriteLine("Found A");
            //}

            /// for palindrome
            var palindrome = from palin in names
                             orderby palin descending
                             select IsPalindrome(palin);
            foreach (var item in palindrome)
            {
                Console.WriteLine(item);
            }
        }
        public static string IsPalindrome(string palin)
        {
            string rev = new string(palin.Reverse().ToArray());
            if (rev == palin)
                return "Palindrome " + palin;

            return "Not Palindrome " + palin;
        }
    }
}
