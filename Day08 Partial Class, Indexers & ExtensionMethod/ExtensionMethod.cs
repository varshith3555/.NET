using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace MyConsoleApp.Day8
{
    public static class ExtensionMethod
    {
        public static int WordCount(this string word)
        {
            return word.Count(c  => c == ' ') + 3;
        }
    }
}
