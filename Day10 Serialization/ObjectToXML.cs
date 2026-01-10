using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

// Serialization

namespace MyConsoleApp.Day10
{
   public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] arr;
        public List<int> scores { get; set; }
        public Employee()
        {
            scores = new List<int> { 85, 90, 78, 92 };
        }
    }

    class Employee2
    {
        static void Main()
        {
            Employee emp = new Employee
            { // Create object
                Id = 1,
                Name = "XML",
                arr = new int[] { 1, 2 }
            };


            /// We use XmlSerializer class to convert an object into XML.
            
            //XmlSerializer xml = new XmlSerializer(typeof(Employee));
            //using (StringWriter  sw = new StringWriter())
            //{
            //    xml.Serialize(sw, emp);
            //    string xmlStr = sw.ToString();
            //    Console.WriteLine(xmlStr);
            //} 
            // or 
            //XmlSerializer xml = new XmlSerializer(emp.GetType());
            //xml.Serialize(Console.Out, emp);


            // SERIALIZATION: Object → JSON
            string jsonData = JsonSerializer.Serialize(emp);
            Console.WriteLine(jsonData);
            
            Employee newemp = JsonSerializer.Deserialize<Employee>(jsonData);
            Console.WriteLine(newemp.Id);
            Console.WriteLine(newemp.Name);
            Console.WriteLine("Scores: " + string.Join(",", newemp.scores));

        }
    }
}
