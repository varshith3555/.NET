using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    public class Constructor1
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; }
        public Constructor1(int a, int b)
        {
            this.a = a;
            this.b = b;
            this.c = a + b; // only in constructer get properties can be set(result have only get in declaration)
            //Console.WriteLine("Result: ",c);
        }
    }
    public class Addition
    {
        public static void Main(string[] args)
        {
            Constructor1 con = new Constructor1(10,30);
            Console.WriteLine(con.c);
        }
    }
}
