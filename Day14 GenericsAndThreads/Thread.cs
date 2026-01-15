using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day14_GenericsAndThreads
{
    public class Threads
    {
        public static void Main()
        {
            Thread t1 = new Thread(Task1);
            Thread t2 = new Thread(Task2);
            t1.Start();
            t2.Start();
            t2.Join();
        }

        static void Task1()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.Write(i + "*");
                Thread.Sleep(1000);
            }
        }
        static void Task2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " ");
                Thread.Sleep(1000);
            }
        }
    }
}
