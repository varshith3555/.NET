using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    public class Father
    {
        public virtual string InterestOn()
        {
            return "Parent class";
        }
    }
    public class Son : Father
    {
        public override string InterestOn()
        {
            return "Child class is overriding the parent class";
        }
    }
    public class MethodOverRidingMain
    {
        public static void Main(string[] args)
        {
            Father f = new Son();
            string res = f.InterestOn();
            Console.WriteLine(res);
        }
    }
}
