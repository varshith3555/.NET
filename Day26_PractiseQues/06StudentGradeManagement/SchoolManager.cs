using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagement
{
    public  class SchoolManager
    {
        private List<Student> stu = new List<Student>();
        // Auto-generate StudentId
        private int id = 1001;
        public void AddStudent(string name, string gradeLevel)
        {
            if(string.IsNullOrWhiteSpace(name)){
                throw new ArgumentException("Student name cannot be empty.");
            }

            stu.Add(new Student{
               StudentId = id++, Name = name, GradeLevel = gradeLevel
            });
        }

        // Adds grade for student (0-100 scale)
        public void AddGrade(int studentId, string subject, double grade)
        {
            if(grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            var student = stu.FirstOrDefault(s => s.StudentId == studentId);
            if(student == null)
                throw new Exception("Student not found.");

            student.Subjects[subject] = grade;
        }

        // Groups students by grade level
        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            var grouped = new SortedDictionary<string, List<Student>>();
            foreach(var student in stu)
            {
                if(!grouped.ContainsKey(student.GradeLevel))
                    grouped[student.GradeLevel] = new List<Student>();
                grouped[student.GradeLevel].Add(student);
            }
            return grouped;
        }   

        // Returns student's average grade
        public double CalculateStudentAverage(int studentId)
        {
            var student = stu.FirstOrDefault(s => s.StudentId == studentId);
            if(student == null)
                throw new Exception("Student not found.");

            if(student.Subjects.Count == 0)
                return 0;

            return student.Subjects.Values.Average();
        }

        // Returns average grade per subject across all students
        public Dictionary<string, double> CalculateSubjectAverages()
        {
            var subjectAverages = new Dictionary<string, double>();
            var allSubjects = new Dictionary<string, List<double>>();

            foreach(var student in stu)
            {
                foreach (var subject in student.Subjects)
                {
                    if (!allSubjects.ContainsKey(subject.Key))
                        allSubjects[subject.Key] = new List<double>();
                    allSubjects[subject.Key].Add(subject.Value);
                }
            }

            foreach(var subject in allSubjects)
            {
                subjectAverages[subject.Key] = subject.Value.Average();
            }

            return subjectAverages;
        }

        // Returns top N students by average grade
        public List<Student> GetTopPerformers(int count)
        {
            return stu
                .OrderByDescending(s => CalculateStudentAverage(s.StudentId))
                .Take(count)
                .ToList();
        }
    }
}
