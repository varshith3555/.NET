using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day3
{
    internal class Classes
    {
        public string Name;
        public int StudentId;
        public string Course;
        public int Marks;

        public void DisplayDetails()
        {
            Console.WriteLine("StudentID: " + StudentId);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Course: " + Course);
            Console.WriteLine("Total Marks: " + Marks);
        }
        public void IsPassed()
        {
            if (Marks >= 150)
            {
                Console.WriteLine("Student Passed.");
            }
            else
            {
                Console.WriteLine("Student Failed");
            }
        }

    }
    public class Student
    {
        public static void Main()
        {
            Classes student = new Classes();
            student.StudentId = 12201442;
            student.Name = "Varshith Reddy";
            student.Course = "CSE";
            student.Marks = 200;
            student.DisplayDetails();
            // student.IsPassed();

        }
    }
}
