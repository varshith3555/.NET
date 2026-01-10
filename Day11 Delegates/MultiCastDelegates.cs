using System;

namespace MyConsoleApp.Day11
{
    public class MultiCastDelegates
    {
        // Delegate declaration
        public delegate void Delegates(string msg);

        // Methods to attach
        static void MethodA(string msg) => Console.WriteLine("A: " + msg);
        static void MethodB(string msg) => Console.WriteLine("B: " + msg);
        static void MethodC(string msg) => Console.WriteLine("C: " + msg);

        static void Main()
        {
            Delegates d = MethodA;
            d += MethodB;
            d += MethodC;

            // Invoke multicast delegate
            d("Hello");
        }
    }
}
