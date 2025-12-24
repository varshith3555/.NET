using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day5_Abstract___Project_References
{
    public abstract class LoginAbs
    {
        public abstract void LogIn(string username, string password);
        public abstract void LogOut();

        public bool LogInProcess()
        {
            return true;
        }
    }
}
