using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day14
{
    public class Program
    {
        static void Main()
        {
            GenericsType<UGStudent> global = new GenericsType<UGStudent>();
            UGStudent obj = new UGStudent();
            string result = global.GetDataType(obj);
            Console.WriteLine(result);

            // Predicate
            bool check = DelegateTypes.IsEven(10);
            Console.WriteLine(check);

            //Action
            DelegateTypes.logger("Started ");


            string res = DelegateTypes.multiplyResult(5, 4);
            Console.WriteLine(res);

        }
    }
}
