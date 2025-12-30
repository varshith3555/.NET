using MyConsoleApp.Day7.ExamSchedule.Model.cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day7.ExamSchedule.Data
{
    public class DataBank
    {
        public static List<Students> students = new List<Students>();
        public static List<StudentSession> sessions = new List<StudentSession>();
        static DataBank()
        {
            students = new List<Students>()
            {
                new Students() { Id = 1, Name = "Varshith" },
                new Students() { Id = 2, Name = "Nani" },
            };
            sessions = new List<StudentSession>()
            {
                new StudentSession() {Id = 1, Name = "Capp" },
                new StudentSession() {Id = 2, Name ="Acc" },
            };
        }

        public static List<Students> GetStudents()
        {
            return students;
        }
        public static List<StudentSession> GetSessions()
        {
            return sessions;
        }  
    }
}
