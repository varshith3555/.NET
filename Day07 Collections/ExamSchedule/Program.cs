using System;
using System.Collections.Generic;
using System.Text;
using MyConsoleApp.Day7.ExamSchedule.Data;

namespace MyConsoleApp.Day7.ExamSchedule
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var localStudents = DataBank.GetStudents();

            foreach(var student in localStudents)
            {
                Console.WriteLine(student.Name);
            }

            var sessions = DataBank.GetSessions();

            foreach (var session in sessions)
            {
                Console.WriteLine(session.Name);
            }
        }
    }
}
