using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day8
{
    public class StaticConstructor
    {
        public static int RollNo;
        static StaticConstructor()
        {
            RollNo = 1;
        }
        public static int GetRollNo()
        {
            return RollNo;
        } 
    }
}
