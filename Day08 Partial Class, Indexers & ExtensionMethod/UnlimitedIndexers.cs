using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day8
{
    public class UnlimitedIndexers
    {
        private List<int> num = new List<int>();
        public int this[int index]
        {
            get
            {
                return num[index];
            }
            set
            {
                while(index >= num.Count)
                {
                    num.Add(0);
                }
                num[index] = value;
            }
        }
    }
    class unlimited
    {
        public static void Main()
        {
            UnlimitedIndexers u = new UnlimitedIndexers();
            u[0] = 1;
            u[1] = 2;
            u[2] = 3;
            Console.WriteLine(u[0]);
            Console.WriteLine(u[1]);
            Console.WriteLine(u[2]);
        }
    }
}
