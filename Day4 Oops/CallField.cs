using System;
using System.Collections.Generic;
using System.Text;

/// from ExFeild.cs
namespace MyConsoleApp.Day4
{
    public class CallField
    {
        public static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Id = 100;
            string result = employee.DisplayEmpDetails();
            Console.WriteLine(result);
        }
    }
}
