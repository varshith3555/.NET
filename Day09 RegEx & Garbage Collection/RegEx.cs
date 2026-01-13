using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyConsoleApp.Day9
{
    public class RegEx
    {
        static void Main()
        {
            string input = "Error: TIMEOUT while calling API";
            string pattern = @"timeout";

            var rx = new Regex(
                pattern,
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(150) // match timeout
            );

            Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
        }
    }
}
