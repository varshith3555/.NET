using System;
using System.Collections.Generic;
using System.Linq;

// Base constraints
public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}
public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    // TODO: Enroll student with constraints
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if(!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        if(_enrollments[course].Count >= course.MaxCapacity)
            return false;

        if(_enrollments[course].Any(s => s.StudentId == student.StudentId))
            return false;

        if(course is LabCourse lab && student.Semester < lab.RequiredSemester)
            return false;
        _enrollments[course].Add(student);
        return true;
    }

    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.ContainsKey(course))
            return _enrollments[course].AsReadOnly();
        return new List<TStudent>().AsReadOnly();
    }

    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments.Where(e => e.Value.Any(s => s.StudentId == student.StudentId)).Select(e => e.Key);
    }

    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student).Sum(c => c.Credits);
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollmentSystem;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollmentSystem)
    {
        _enrollmentSystem = enrollmentSystem;
    }

    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if(grade < 0 || grade > 100)
            return;

        if(!_enrollmentSystem.GetStudentCourses(student).Contains(course))
            return;
        _grades[(student, course)] = grade;
    }

    // TODO: Calculate GPA
    public double? CalculateGPA(TStudent student)
    {
        var records = _grades.Where(g => g.Key.Item1.StudentId == student.StudentId);

        if(!records.Any())
            return null;

        double total = 0;
        int credits = 0;

        foreach(var r in records)
        {
            total += r.Value * r.Key.Item2.Credits;
            credits += r.Key.Item2.Credits;
        }
        return total / credits;
    }

    // TODO: Find top student in course
    public(TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var result = _grades
            .Where(g => g.Key.Item2.Equals(course))
            .OrderByDescending(g => g.Value)
            .FirstOrDefault();

        if(result.Key.Item1 == null)
            return null;

        return(result.Key.Item1, result.Value);
    }
}

// 4. TEST SCENARIO
class Programs
{
    static void Main()
    {
        var system = new EnrollmentSystem<EngineeringStudent, LabCourse>();

        var s1 = new EngineeringStudent { StudentId = 1, Name = "A", Semester = 3 };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "B", Semester = 5 };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "C", Semester = 2 };

        var c1 = new LabCourse
        {
            CourseCode = "CS301",
            Title = "DS Lab",
            MaxCapacity = 2,
            Credits = 3,
            RequiredSemester = 3
        };

        var c2 = new LabCourse
        {
            CourseCode = "CS401",
            Title = "OS Lab",
            MaxCapacity = 1,
            Credits = 4,
            RequiredSemester = 5
        };

        system.EnrollStudent(s1, c1);
        system.EnrollStudent(s2, c1);
        system.EnrollStudent(s3, c1);
        system.EnrollStudent(s2, c2);

        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(system);
        gradeBook.AddGrade(s1, c1, 80);
        gradeBook.AddGrade(s2, c1, 90);
        gradeBook.AddGrade(s2, c2, 85);

        Console.WriteLine(gradeBook.CalculateGPA(s2));
        var top = gradeBook.GetTopStudent(c1);
        Console.WriteLine($"{top?.student.Name} {top?.grade}");
    }
}
