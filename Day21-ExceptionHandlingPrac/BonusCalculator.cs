public class BonusCalculator
{
    static  void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 1000;

        for(int i = 0; i < salaries.Length; i++)
        {
            try
            {
                int result = bonus/salaries[i];
                Console.WriteLine("Bonus per unit for employee " + (i + 1) + ": " + result);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}