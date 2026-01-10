using System;
using System.Collections.Generic;
using System.Text;

//take semester as 1,2,3 and also take 4-5 subjects and convert subject as 1.1 means 1sem 1sub and keep it in an array store as [2,5] means 2 semesters 5 subjects
namespace MyConsoleApp.Day12
{
    public enum Semester
    {
        Sem1 = 1,
        Sem2 = 2
    }

    public enum Subject
    {
        Maths = 1,
        Phy = 2,
        Chy = 3,
    }

    public class EnumExampleMain
    {
        static void Main()
        {
            string[,] subMap = new string[2, 3];
            int semIdx = 0;

            foreach (Semester sem in Enum.GetValues(typeof(Semester)))
            {
                int subIdx = 0;
                foreach (Subject sub in Enum.GetValues(typeof(Subject)))
                {
                    subMap[semIdx, subIdx] = $"{(int)sem}.{(int)sub}";
                    subIdx++;
                }
                semIdx++;
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(subMap[i, j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
