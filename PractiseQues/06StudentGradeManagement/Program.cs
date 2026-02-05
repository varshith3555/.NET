using System;

namespace StudentGradeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Student Grade Management System");

            var schoolManager = new SchoolManager();

            // Add students
            schoolManager.AddStudent("Alice Johnson", "10th");
            schoolManager.AddStudent("Bob Smith", "10th");
            schoolManager.AddStudent("Charlie Brown", "11th");
            schoolManager.AddStudent("Diana Prince", "11th");
            schoolManager.AddStudent("Eve Davis", "12th");

            // Add grades for students
            schoolManager.AddGrade(1001, "Math", 85);
            schoolManager.AddGrade(1001, "English", 90);
            schoolManager.AddGrade(1001, "Science", 88);

            schoolManager.AddGrade(1002, "Math", 92);
            schoolManager.AddGrade(1002, "English", 85);
            schoolManager.AddGrade(1002, "Science", 91);

            schoolManager.AddGrade(1003, "Math", 78);
            schoolManager.AddGrade(1003, "English", 82);
            schoolManager.AddGrade(1003, "Science", 80);

            schoolManager.AddGrade(1004, "Math", 95);
            schoolManager.AddGrade(1004, "English", 93);
            schoolManager.AddGrade(1004, "Science", 94);

            schoolManager.AddGrade(1005, "Math", 88);
            schoolManager.AddGrade(1005, "English", 86);
            schoolManager.AddGrade(1005, "Science", 89);

            // Display student averages
            Console.WriteLine("Student Averages:");
            for(int i = 1001; i <= 1005; i++)
            {
                double avg = schoolManager.CalculateStudentAverage(i);
                Console.WriteLine($"Student ID {i}: {avg:F2}");
            }

            // Display subject averages
            Console.WriteLine("\nSubject Averages:");
            var subjectAvgs = schoolManager.CalculateSubjectAverages();
            foreach(var subject in subjectAvgs)
            {
                Console.WriteLine($"{subject.Key}: {subject.Value:F2}");
            }

            // Display grouped students
            Console.WriteLine("\nStudents Grouped by Grade Level:");
            var grouped = schoolManager.GroupStudentsByGradeLevel();
            foreach(var group in grouped)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var student in group.Value)
                {
                    Console.WriteLine($"  - {student.Name} (ID: {student.StudentId})");
                }
            }

            // Display top performers
            Console.WriteLine("\nTop 2 Performers:");
            var topPerformers = schoolManager.GetTopPerformers(2);
            foreach(var student in topPerformers)
            {
                double avg = schoolManager.CalculateStudentAverage(student.StudentId);
                Console.WriteLine($"{student.Name}: {avg:F2}");
            }
        }
    }
}
