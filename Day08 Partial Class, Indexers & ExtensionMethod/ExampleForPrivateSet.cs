using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// if we remove the set in property then we need to use and default constructor and parametrized constructor to set the values
/// if we keep as private set then it will be accessed within the class using functions not only contructors
namespace MyConsoleApp.Day8
{
    public partial class YoungProfessional
    {
        public YoungProfessional()
        {

        }
        public YoungProfessional(string dob)
        {
            DateOfBirth = dob;

        }
        public int PersonalId { get; private set; }
        public int RNo { get; set; }
        public string DateOfBirth { get; private set; }

        public string Name { get; set; }


        public void SetDateOfBirth(string dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }
        

    }

    public class PrivateSet
    {
        static void Main(string[] args)
        {
            YoungProfessional yp = new YoungProfessional();
        }
    }

}
