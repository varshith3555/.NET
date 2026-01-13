using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day13_LINQ
{
    public class MarkStudent
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Marks1 { get; set; }
        public double Marks2 { get; set; }
    }

    public class StudentManager
    {
        public static void Main()
        {
            List<MarkStudent> ms = new List<MarkStudent>
            {
                new MarkStudent(){Id = 1, Name = "Avishek", Marks1 = 23, Marks2 = 25},
                new MarkStudent(){Id = 2, Name = "Varshith", Marks1 = 80, Marks2 = 34 },
            };
               
            var TotalStudent = from s in ms select new {s.Id,  s.Name, Total = s.Marks1 + s.Marks2};
            foreach(var item in TotalStudent)
            {
                Console.WriteLine($"Id: { item.Id} Name: { item.Name} Avg: { item.Total}");
            }

            var TopStudent = TotalStudent.OrderByDescending(s => s.Total).First();
            Console.WriteLine(TopStudent.Name + "- " + TopStudent.Total);


        }
    }
}