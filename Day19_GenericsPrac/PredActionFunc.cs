namespace MyConsoleApp.Day19_Generics;
class Program
{
    public static void Main()
    {
        List<int> marks = new() { 30, 45, 60, 25 };
        Predicate<int> isFail = m => m < 40;

        Action<int> printFail = m => Console.WriteLine($"{m} → Failed");
        
        Func<int, string> grade = m => m >= 60 ? "A" : m >= 40 ? "B" : "F";

        foreach(int m in marks)
        {
            if(isFail(m))
                printFail(m);

            Console.WriteLine($"Marks: {m}, Grade: {grade(m)}");
        }
    }
} 
