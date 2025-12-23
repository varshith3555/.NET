using System;
using System.Collections.Generic;
using System.Text;

// Encapsulation

namespace MyConsoleApp.Day4
{
    public class Associate
    {
        /// <summary>
        /// Private fields – data is hidden from outside
        /// </summary>
        private int id;
        private string name;
        private int rank;
        public string Error;

        /// <summary>
        /// Public property for Id with validation
        /// </summary>
        public int Id
        {
            get { return id; }  // Read access
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    id = 0;
                    Error += "Id must be greater than zero\n";
                }
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    name = "Not Provided";
                    Error += "Name must be entered\n";
                }
            }
        }
        public int Rank
        {
            get { return rank; }
            set
            {
                if (value > 0)
                {
                    rank = value;
                }
                else
                {
                    rank = 0;
                    Error += "Rank must be greater than zero\n";
                }
            }

        }
        /// <summary>
        /// Method to display details of the associate
        /// </summary>
        /// <returns></returns>
        public string DisplayDetails()
        {
            return $"Employee Details: \nID: {id}\nName: {name}\nRank: {rank}";
        }
    }
    public class AssociateMain
    {
        public static void Main(string[] args)
        {
            Associate asco = new Associate();
            //Assign values to properties
            asco.Id = 12201442;
            asco.Name = string.Empty;
            asco.Rank = -1;
            string result = asco.DisplayDetails();
            Console.WriteLine(asco.Error);
            Console.WriteLine(result);
        }
    }
}