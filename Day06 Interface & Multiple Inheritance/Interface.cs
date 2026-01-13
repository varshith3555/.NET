using System;

namespace MyConsoleApp.Day6
{
    // Interface
    public interface IPrint
    {
        void Print();
    }

    // Class implementing interface
    public class Student : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Student details printed");
        }
        public void Study()
        {
            Console.WriteLine("Study");
        }
    }

    // Main Class
    class Interface
    {
        public static void Main(string[] args)
        {
            Student s = new Student();
            s.Print();
            s.Study();
        }
    }
}
