using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day8
{
    class PartialMain
    {
        public static void Main()
        {
            //PartialClass pc = new PartialClass();
            //pc.Show();


            //Console.WriteLine(StaticConstructor.GetRollNo());

            string sent = "Capp training";
            int count = sent.WordCount();
            Console.WriteLine(count);
        }
    }
}
