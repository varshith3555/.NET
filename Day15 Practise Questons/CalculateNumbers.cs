using System;

namespace MyConsoleApp.Day15_Practise_Questons
{
    public class Q3
    {
        public static List<int> list = new List<int>();

        public static void AddNumber(int number)
        {
            list.Add(number);
        }
        public static double GetGPAScored()
        {
            if(list.Count == 0)
            {
                return -1;
            }
            int total = 0;
            foreach(var n in list)
            {
                total += n * 3;
            }

            double gpa = (double)total / (list.Count);
            return gpa;
        }
        public static char GetGradeScored(double gpa)
        {
            if(gpa < 5 || gpa > 10)
            {
                return '\0';
            }
            if(gpa == 10)
            {
                return 'S';
            }
            else if(gpa >=9 && gpa < 10)
            {
                return 'A';
            }else if(gpa >= 8 && gpa < 9)
            {
                return 'B';
            }else if(gpa >= 7 && gpa < 8)
            {
                return 'C';
            }else if(gpa >= 6 && gpa < 7)
            {
                return 'D';
            }else
            {
                return 'E';
            }
        }
        static void Main()
        {
            Console.WriteLine("Enter the no of subjects");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter marks");
                int marks = int.Parse(Console.ReadLine());
                AddNumber(marks);
            }

            double gpa = GetGPAScored();
            Console.WriteLine("GPA: " + gpa);

            char grade = GetGradeScored(gpa);

            if (grade == '\0')
                Console.WriteLine("Invalid GPA");
            else
                Console.WriteLine("Grade: " + grade);

        }
    }
}
