using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day14
{
    public class Student
    {
        public int Id { get; set; }
    }
    public class UGStudent : Student
    {
        public int HighSchoolMark { get; set; }
    }
    public class PGStudent : UGStudent
    {
        public int PgMArk { get; set; }
    }

    public class GenericsType<T>   /// T is a placeholder type
    {
        public string GetDataType(T t)
        {
            return t.GetType().ToString();
        }
    }
}
