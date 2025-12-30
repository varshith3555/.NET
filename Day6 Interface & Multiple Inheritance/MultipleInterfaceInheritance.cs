using System;
using System.Collections.Generic;
using System.Text;


/// This program demonstrates Multiple Inheritance using Interfaces in C#
/// Note: C# does NOT support multiple inheritance of classes, but it supports multiple inheritance through interfaces.

namespace MyConsoleApp.Day6
{
    public interface IVegEater
    {
        void Veg();
        
        string GetTaste(); /// Same method name exists in both interfaces 
        //or 
        // void GetTaste();

    }
    public interface INonVegEater
    {
        void NonVeg();
        string GetTaste(); //or void GetTaste();

    }

    // Visitor class implements both interfaces
    public class Visitor : IVegEater, INonVegEater
    {
        // Normal implementation of Veg method
        public void Veg()
        {
            Console.WriteLine("This is normal veg method");
        }
        
        public void NonVeg()
        {
            Console.WriteLine("This is normal NonVeg method");
        }

        // explicit interface implementation
        string IVegEater.GetTaste()
        {
            return "This is Veg Taste";
        }

        string INonVegEater.GetTaste()
        {
            return "This is Non Veg Taste";
        }

        //void IVegEater.GetTaste()
        //{
        //    Console.WriteLine("Veg Taste");
        //}
        //// explicit interface
        //void INonVegEater.GetTaste()
        //{
        //    Console.WriteLine("NonVeg Taste");
        //}
    }

    public class MultipleInterfaceInheritance
    {
        public static  void Main(string[] args)
        {
            Visitor visitor = new Visitor();
            /// Calling normal class methods
            visitor.Veg();
            visitor.NonVeg();


            /// Creating interface references
            /// This is required to access explicitly implemented methods
            IVegEater v = new Visitor();
            string veg = v.GetTaste();
            Console.WriteLine(veg);

            INonVegEater nv = new Visitor();
            Console.WriteLine(nv.GetTaste());
        }
    }
}
