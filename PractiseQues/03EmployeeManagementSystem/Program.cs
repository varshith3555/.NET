using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create HRManager object
        HRManager hr = new HRManager();

        // Add employees to different departments
        hr.AddEmployee("Varshith", "IT", 60000);
        hr.AddEmployee("Avishek", "HR", 45000);
        hr.AddEmployee("Rahul", "Sales", 50000);
        hr.AddEmployee("Asad", "IT", 70000);

        // Display department-wise employee lists
        Console.WriteLine(" Employees Grouped by Department:");
        SortedDictionary<string, List<Employee>> groupedEmployees =
            hr.GroupEmployeesByDepartment();

        foreach (var dept in groupedEmployees)
        {
            Console.WriteLine($"\nDepartment: {dept.Key}");
            foreach (var emp in dept.Value)
            {
                Console.WriteLine(
                    $"Name: {emp.Name}, Salary: {emp.Salary}, Joined: {emp.JoiningDate.ToShortDateString()}"
                );
            }
        }

        // Calculate total salary per department
        Console.WriteLine("\n Total Salary for IT Department:");
        double totalITSalary = hr.CalculateDepartmentSalary("IT");
        Console.WriteLine(totalITSalary);

        // Find employees who joined after a specific date
        Console.WriteLine("\n Employees Joined After Yesterday:");
        DateTime yesterday = DateTime.Now.AddDays(-1);
        List<Employee> recentEmployees = hr.GetEmployeesJoinedAfter(yesterday);

        foreach (var emp in recentEmployees)
        {
            Console.WriteLine(emp.Name);
        }
    }
}
