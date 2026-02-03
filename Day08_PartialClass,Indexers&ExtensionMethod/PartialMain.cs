using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day8
{
    class PartialMain
    {
        public static void Main()
        {
            PartialClass s = new PartialClass();
            s.Id = 1;
            s.Name = "John";
            s.Course = "C#";

            s.Display();
            s.ShowCourse();

            //string sent = "Capp training";
            //int count = sent.WordCount();
            //Console.WriteLine(count);
        }
    }
}
