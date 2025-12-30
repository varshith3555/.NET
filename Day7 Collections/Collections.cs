using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day7
{
    public  class Collections
    {
        public static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(2);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Stack s = new Stack();
            s.Push(1);
            s.Push(2);
            s.Pop();
            foreach (var item in s)
            {
                Console.WriteLine(item);
            }


        }

    }
}
