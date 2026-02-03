using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day8
{
    public partial class PartialClass
    {
        public int Id;
        public string Name;

        public void Display()
        {
            Console.WriteLine($"Id: {Id}, Name: {Name}");
        }
    }
}
