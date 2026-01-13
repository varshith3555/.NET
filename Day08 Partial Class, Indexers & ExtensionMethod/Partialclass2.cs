using System;
using System.Collections.Generic;
using System.Text;
/// create two classes with same name means the partial class and create he methods in it and try to access methods in class1 in class2

namespace MyConsoleApp.Day8
{
    public partial class PartialClass
    {
        public string Course;

        public void ShowCourse()
        {
            Console.WriteLine($"Course: {Course}");
        }
    }
}
