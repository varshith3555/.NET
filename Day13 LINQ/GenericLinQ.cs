using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day13_LINQ
{
    public class Employee
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
    }

    public class ExampleOfGenericLinq
    {
        public static List<Employee> employees = new List<Employee>();

        public static void Main()
        {
            var localEmpList = GetData();
            var fileterList = from emp in localEmpList
                              select emp;
            foreach (var emp in fileterList)
            {
                Console.WriteLine(emp.Id + emp.Name + emp.RollNo);
            }
        }

        public static List<Employee> GetData()
        {
            employees.Add(new Employee() { Id=1, Name="Capp", RollNo=1});
            employees.Add(new Employee() { Id = 2, Name = "OnSIte", RollNo = 2 });
            employees.Add(new Employee() { Id = 3, Name = "Training", RollNo = 3 });
            return employees;
        }
    }
}
