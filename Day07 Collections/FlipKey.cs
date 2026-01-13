using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day7
{
    public class FlipKey
    {

        public string CleanseAndInvert(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return "";
            }
            /// check for No spaces, digits, or special characters
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return "";
                }
            }
            /// convert input to lowercase
            input = input.ToLower();

            /// Remove characters with even ASCII values
            string ascii = "";
            foreach(char c in input)
            {
                if((int)c % 2 != 0){
                    ascii += c; 
                }
            }

            /// Reverse the string 
            char[] arr = ascii.ToCharArray();
            Array.Reverse(arr);
            string rev = new string(arr);


            char[] res = rev.ToCharArray();
            for (int i=0; i < res.Length; i++)
            {
                if(i % 2 == 0)
                {
                    res[i] = char.ToUpper(res[i]);
                }
            }
            return new string(res);
        }
    }
    public class KeyMain
    {
        public static void Main(string[] args)
        {
            FlipKey k = new FlipKey();
            Console.WriteLine("Enter the word");
            string input = Console.ReadLine();

            string key = k.CleanseAndInvert(input);
            if (key == "")
                Console.WriteLine("Invalid Input");
            else
                Console.WriteLine("The generated key is - " + key);
        }
    }
}
