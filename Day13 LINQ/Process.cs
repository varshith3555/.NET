using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyConsoleApp.Day13_LINQ
{
    public class LinqExample
    {
        static void Main()
        {
            LINQ();
            LINQ2();
        }

        private static void LINQ()
        {
            var procCollection =
                from p in Process.GetProcesses()
                select new MyProcess { Name = p.ProcessName, Id = p.Id };

            foreach (var proc in procCollection)
            {
                Console.WriteLine("Process: " + proc.Name + " Id: " + proc.Id);
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
        private class MyProcess
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }

        
        /// Anonymous data type and the class will be created by microsoft or c# compiler
        private static void LINQ2()
        {
            var procCollection =
                from p in Process.GetProcesses()
                select new { Name = p.ProcessName, Id = p.Id };

            foreach (var proc in procCollection)
            {
                Console.WriteLine("Process: " + proc.Name + " Id: " + proc.Id);
            }
        }
    }
}
