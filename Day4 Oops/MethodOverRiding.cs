using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    /// <summary>
    /// Parent class or Base
    /// </summary>
    public class Father
    {
        /// <summary>
        /// Virtual method allows derived classes to override it.
        /// </summary>
        /// <returns></returns>
        public virtual string InterestOn()
        {
            return "Parent class";
        }
    }
    public class Son : Father
    {
        /// <summary>
        /// Overrides the parent class method.
        /// </summary>
        /// <returns></returns>
        public override string InterestOn()
        {
            return "Child class is overriding the parent class";
        }
    }
    public class MethodOverRidingMain
    {
        public static void Main(string[] args)
        {
            /// Create a reference of type Father but an object of type Son
            Father f = new Son();
            /// Calls the overridden method in the Son class due to runtime polymorphism
            string res = f.InterestOn();
            Console.WriteLine(res);
        }
    }
}
