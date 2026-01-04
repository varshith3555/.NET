using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day9
{
    public static class ExtensionPalindrome
    {
        public static bool IsPalindrome(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return false;

            string str = text.Replace(" ", "").ToLower();

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (str[left] != str[right]) return false;

                left++;
                right--;
            }
            return true;
        }
    }
    class ExtensionMain
    {
        public static void Main()
        {
            string word = "CAC";
            bool res = word.IsPalindrome();
            Console.WriteLine(res);
        }
    }
}


