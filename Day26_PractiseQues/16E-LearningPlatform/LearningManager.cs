namespace _16ELearningPlatform
{
    public class LearningManager
    {
        private List<Course> courses;
        private List<Enrollment> enrollments;
        private List<StudentProgress> studentProgresses;
        private int enrollmentIdCounter;

        public LearningManager()
        {
            courses = new List<Course>();
            enrollments = new List<Enrollment>();
            studentProgresses = new List<StudentProgress>();
            enrollmentIdCounter = 1;
        }

        public void AddCourse(string code, string name, string instructor, int weeks, double price, List<string> modules)
        {
            if (courses.Any(c => c.CourseCode == code))
            {
                Console.WriteLine($"Course with code {code} already exists!");
                return;
            }

            courses.Add(new Course
            {
                CourseCode = code,
                CourseName = name,
                Instructor = instructor,
                DurationWeeks = weeks,
                Price = price,
                Modules = new List<string>(modules)
            });
            Console.WriteLine($"Course '{name}' added successfully!");
        }

        public bool EnrollStudent(string studentId, string courseCode)
        {
            if (!courses.Any(c => c.CourseCode == courseCode))
            {
                Console.WriteLine($"Course with code {courseCode} not found!");
                return false;
            }

            if (enrollments.Any(e => e.StudentId == studentId && e.CourseCode == courseCode))
            {
                Console.WriteLine($"Student {studentId} is already enrolled in course {courseCode}!");
                return false;
            }

            enrollments.Add(new Enrollment
            {
                EnrollmentId = enrollmentIdCounter++,
                StudentId = studentId,
                CourseCode = courseCode,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0
            });

            studentProgresses.Add(new StudentProgress
            {
                StudentId = studentId,
                CourseCode = courseCode,
                LastAccessed = DateTime.Now
            });

            Console.WriteLine($"Student {studentId} enrolled in course {courseCode} successfully!");
            return true;
        }

        public bool UpdateProgress(string studentId, string courseCode, string module, double score)
        {
            var progress = studentProgresses.FirstOrDefault(sp => sp.StudentId == studentId && sp.CourseCode == courseCode);
            if (progress == null)
            {
                Console.WriteLine($"Progress record not found for student {studentId} in course {courseCode}!");
                return false;
            }

            progress.ModuleScores[module] = score;
            progress.LastAccessed = DateTime.Now;

            var course = courses.First(c => c.CourseCode == courseCode);
            var totalScore = progress.ModuleScores.Values.Sum();
            var progressPercentage = (totalScore / (course.Modules.Count * 100)) * 100;

            var enrollment = enrollments.First(e => e.StudentId == studentId && e.CourseCode == courseCode);
            enrollment.ProgressPercentage = progressPercentage;

            Console.WriteLine($"Progress updated for {studentId}: {module} = {score}");
            return true;
        }

        public Dictionary<string, List<Course>> GroupCoursesByInstructor()
        {
            return courses.GroupBy(c => c.Instructor)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Enrollment> GetTopPerformingStudents(string courseCode, int count)
        {
            return enrollments.Where(e => e.CourseCode == courseCode)
                .OrderByDescending(e => e.ProgressPercentage)
                .Take(count)
                .ToList();
        }
    }
}
