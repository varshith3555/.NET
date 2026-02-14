namespace _16ELearningPlatform
{
    public class StudentProgress
    {
        public string StudentId { get; set; }
        public string CourseCode { get; set; }
        public Dictionary<string, double> ModuleScores { get; set; }
        public DateTime LastAccessed { get; set; }

        public StudentProgress()
        {
            ModuleScores = new Dictionary<string, double>();
        }
    }
}
