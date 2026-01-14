using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day14
{
    public class DelegateTypes
    {
        // These predicate and action comes under delegate
        // Predicate -for methods that test condition and always takes ipout and returns bool
        public static Predicate<int> IsEven = number => number % 2 == 0;

        //For methods that returns void and used for logging, printing, updating UI
        public static Action<string> logger = msg =>
        {
            Console.WriteLine(msg + DateTime.Now);
        };

        public static Func<int, int, string> multiplyResult = (x , y) =>
        {
            return $"{x} times {y} is {x * y}";
        };
        

    }
}
