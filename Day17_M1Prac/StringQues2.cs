using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day17_M1Prac
{
    public class Ques2
    {
        public static bool IsValidUsername(string username)
        {
            if(username.Length != 8)
                return false;

            for(int i = 0; i < 4; i++)
            {
                if (!char.IsUpper(username[i]))
                    return false;
            }

            if(username[4] != '@')
                return false;

            for(int i = 5; i < 8; i++)
            {
                if (!char.IsDigit(username[i]))
                    return false;
            }

            int courseId = int.Parse(username.Substring(5));
            if(courseId < 101 || courseId > 115)
                return false;
            return true;
        }

        public static string GeneratePassword(string username)
        {
            int asciiSum = 0;
            for(int i = 0; i < 4; i++)
            {
                char ch = char.ToLower(username[i]);
                asciiSum += (int)ch;
            }

            string lastTwoDigits = username.Substring(6);
            return "TECH_" + asciiSum + lastTwoDigits;
        }

        public static void Main()
        {
            Console.WriteLine("Enter the username");
            string username = Console.ReadLine();

            if(!IsValidUsername(username))
            {
                Console.WriteLine(username + " is an invalid username");
            }
            else
            {
                string password = GeneratePassword(username);
                Console.WriteLine("Password: " + password);
            }
        }
    }
}
