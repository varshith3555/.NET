namespace _16ELearningPlatform
{
    class Program
    {
        static void Main()
        {
            LearningManager manager = new LearningManager();

            // Add courses
            manager.AddCourse("CS101", "Introduction to C#", "Dr. Smith", 8, 299.99, new List<string> { "Basics", "OOP", "Collections", "LINQ" });
            manager.AddCourse("WEB101", "Web Development", "Dr. Johnson", 10, 399.99, new List<string> { "HTML", "CSS", "JavaScript", "React" });
            manager.AddCourse("DB101", "Database Design", "Prof. Williams", 6, 349.99, new List<string> { "SQL", "NoSQL", "Optimization" });

            // Enroll students
            manager.EnrollStudent("STU001", "CS101");
            manager.EnrollStudent("STU002", "CS101");
            manager.EnrollStudent("STU003", "WEB101");
            manager.EnrollStudent("STU001", "WEB101");

            // Update progress
            manager.UpdateProgress("STU001", "CS101", "Basics", 85);
            manager.UpdateProgress("STU001", "CS101", "OOP", 90);
            manager.UpdateProgress("STU002", "CS101", "Basics", 78);
            manager.UpdateProgress("STU003", "WEB101", "HTML", 88);

            // Group courses by instructor
            var coursesByInstructor = manager.GroupCoursesByInstructor();
            foreach (var group in coursesByInstructor)
            {
                Console.WriteLine($"\nInstructor: {group.Key}");
                foreach (var course in group.Value)
                {
                    Console.WriteLine($"  - {course.CourseName}");
                }
            }

            // Get top performers in CS101
            var topStudents = manager.GetTopPerformingStudents("CS101", 2);
            foreach (var enrollment in topStudents)
            {
                Console.WriteLine($"StudentId: {enrollment.StudentId}, Progress: {enrollment.ProgressPercentage}%");
            }
        }
    }
}
