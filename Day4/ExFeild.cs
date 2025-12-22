using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day4
{
    public class Employee
    {
        /// <summary>
        ///  this is private variable so cannot get the value 
        /// </summary>
        private int id;

        /// <summary>
        /// using public variable we can access the value
        /// </summary>
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
