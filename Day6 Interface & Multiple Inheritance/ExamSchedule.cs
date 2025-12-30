using System;

namespace MyConsoleApp.Day6
{
    // Base abstract class
    public abstract class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }

        public Role Role { get; set; }
        public Department Department { get; set; }

        // abstract method
        public abstract string GetRole();
    }

    // Role class - store role details.
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

    // Department class
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }

    // Subject class
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Department Department { get; set; }
    }

    // HOD class
    public class HOD : Employee
    {
        public override string GetRole() => "HOD";

        public void ScheduleExam(Exam exam, DateTime date, TimeSpan start, TimeSpan end, string venue)
        {
            Console.WriteLine(
                $"HOD {Name} ({Department.DeptName}) scheduled {exam.Subject.SubjectName} exam " +
                $"for Semester {exam.Semester} with {exam.NumberOfStudents} students on {date:d} " +
                $"from {start} to {end} at {venue}");
        }

        public void AssignExaminer(Exam exam, Examiner examiner)
        {
            Console.WriteLine($"HOD {Name} assigned {examiner.Name} to {exam.Subject.SubjectName} exam");
        }
    }

    // Examiner class
    public class Examiner : Employee
    {
        public override string GetRole() => "Examiner";

        public void CheckPaper(Exam exam)
        {
            Console.WriteLine($"Examiner {Name} is checking {exam.Subject.SubjectName} paper");
        }
    }

    // Exam class
    public class Exam
    {
        public int ExamId { get; set; }
        public int Semester { get; set; }
        public int NumberOfStudents { get; set; }
        public Subject Subject { get; set; }
    }

    class ExamSchedule
    {
        static void Main()
        {
            Department cse = new Department { DeptId = 1, DeptName = "CSE" };

            Subject java = new Subject
            {
                SubjectId = 101,
                SubjectName = "Java Programming",
                Department = cse
            };

            HOD hod = new HOD
            {
                EmpId = 1,
                Name = "Dr. Sharma",
                Role = new Role { RoleId = 1, RoleName = "HOD" },
                Department = cse
            };

            Examiner examiner = new Examiner
            {
                EmpId = 2,
                Name = "Prof. Verma",
                Role = new Role { RoleId = 2, RoleName = "Examiner" },
                Department = cse
            };

            Exam exam = new Exam
            {
                ExamId = 1001,
                Semester = 5,
                NumberOfStudents = 10,
                Subject = java
            };

            hod.ScheduleExam(exam, DateTime.Today, new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0), "Hall A");
            hod.AssignExaminer(exam, examiner);
            examiner.CheckPaper(exam);
        }
    }
}

