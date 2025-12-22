using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    public class Associate
    {
        private int id;
        private string name;
        private int rank;
        public string Error;
        public int Id
        {
            set
            {
                if (value > 0)
                {
                    id = value;
                }
                else
                {
                    Error += "Id must be greater than zero\n";
                }
            }
        }
        public string Name
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    Error += "Name must be entered\n";
                }
            }
        }
        public int Rank
        {
            set
            {
                if (value > 0)
                {
                    rank = value;
                }
                else
                {
                    Error += "Rank must be greater than zero\n";
                }
            }

        }
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
            asco.Id = 12201442;
            asco.Name = string.Empty;
            asco.Rank = -1;
            string result = asco.DisplayDetails();
            Console.WriteLine(asco.Error);
            Console.WriteLine(result);
        }
    }
}