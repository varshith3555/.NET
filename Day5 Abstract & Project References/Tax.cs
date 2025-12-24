using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day5_Abstract___Project_References
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public abstract double CalTax();
    }

    public class IndianEmp : Employee
    {
        public override double CalTax()
        {
            if (Salary < 10000)
            {
                return Salary * 0.05; // 5% tax
            }
            else
            {
                return Salary * 0.10; // 10% tax
            }
        }
    }

    public class USEmp : Employee
    {
        public override double CalTax()
        {
            return Salary * 0.15; // 15% tax
        }
    }
    class Tax
    {
        static void Main()
        {
            Employee emp1 = new IndianEmp
            {
                Id = 1,
                Name = "Varshith",
                Salary = 8000
            };

            Employee emp2 = new USEmp
            {
                Id = 2,
                Name = "NAni",
                Salary = 20000
            };

            Console.WriteLine($"Indian Employee Tax: {emp1.CalTax()}");
            Console.WriteLine($"US Employee Tax: {emp2.CalTax()}");
        }
    }

}
