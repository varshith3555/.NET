using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

/// Create a class Student with public properties of RollNo, Name, private string for indexer 

namespace MyConsoleApp.Day8
{
    public class Student
    {
        public int RollNo {  get; set; }
        public string Name { get; set; }
        private string[] values = new string[3];
        
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }

    class StudentMain
    {
        public static void Main()
        {
            Student s = new Student();
            s.RollNo = 1;
            s.Name = "Varshith";
            s[0] = "C#";
            Console.WriteLine(s.RollNo);
            Console.WriteLine(s.Name);
            Console.WriteLine(s[0]);
        }
    }
}

