using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    public class Employee
    {

        private int id;

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
                    id = 0;
                    throw new InvalidOperationException("How id can be less than Zero");
                }
            }
        }

        public string DisplayEmpDetails()
        {
            return $"Employee Id is {id}";
        }
    }
}
