using System.Collections;

namespace Day15_Practise_Questons
{
    class MeditationCenter
    {
        public int MemberId{get; set;}
        public int Age{get; set;}
        public double weight{get; set;}
        public double Height{get; set;}
        public string? Goal{get; set;}
        public double BMI{get; set;}
    }
    class YogaMeditationMain
    {
        public static ArrayList memberList = new ArrayList();

        public void AddYogaMember(int memberId, int age, double weight, double height, string goal)
        {
            MeditationCenter m = new MeditationCenter();
            m.MemberId = memberId;
            m.Age = age;
            m.weight = weight;
            m.Height = height;
            m.Goal = goal;
            m.BMI = 0;
        }
        public double CalculateBMI(int memberId)
        {
            foreach (MeditationCenter member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    double bmi = member.weight / (member.Height * member.Height);

                    // Round to two decimal places using Math.Floor
                    bmi = Math.Floor(bmi * 100) / 100;

                    member.BMI = bmi;
                    return bmi;
                }
            }

            return 0;
        }

        // Method to calculate Yoga Fee
        public int CalculateYogaFee(int memberId)
        {
            foreach (MeditationCenter member in memberList)
            {
                if (member.MemberId == memberId)
                {
                    double bmi = member.BMI;

                    if (member.Goal.Equals("Weight Loss", StringComparison.OrdinalIgnoreCase))
                    {
                        if (bmi >= 25 && bmi < 30)
                            return 2000;
                        else if (bmi >= 30 && bmi < 35)
                            return 2500;
                        else if (bmi >= 35)
                            return 3000;
                    }
                    else if (member.Goal.Equals("Weight Gain", StringComparison.OrdinalIgnoreCase))
                    {
                        return 2500;
                    }
                }
            }
            return 0;
        }

        // Main Method (Sample Usage)
        static void Main(string[] args)
        {
            YogaMeditationMain program = new YogaMeditationMain();

            program.AddYogaMember(101, 25, 70, 1.75, "Weight Loss");

            double bmi = program.CalculateBMI(101);
            if (bmi == 0)
            {
                Console.WriteLine("MemberId 101 is not present");
            }
            else
            {
                Console.WriteLine("BMI: " + bmi);
                int fee = program.CalculateYogaFee(101);
                Console.WriteLine("Yoga Fee: " + fee);
            }
        }
    }
}