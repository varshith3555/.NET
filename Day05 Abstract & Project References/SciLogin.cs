using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day5_Abstract___Project_References
{
    public class SciLogin : LoginAbs
    {
        public override void LogIn(string username, string password)
        {
            Console.WriteLine($"User {username} logged in successfully");
        }

        public override void LogOut()
        {
            Console.WriteLine("User logged out successfully");
        }
    }
}
