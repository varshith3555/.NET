using System;
using System.Runtime.InteropServices;
namespace WeeklyTest
{
    public class InvalidCreditDataException : Exception
    {
        public InvalidCreditDataException(string message) : base(message)
        {
        }
    }

    class CreditRiskProcessor
    {
        public static bool validateCustomerDetails(int age, string employmentType, double monthlyIncome, double dues, int creditScore, int defaults)
        {
            if(age<21 || age > 65)
            {
                throw new InvalidCreditDataException("Invalid age");
            }
            if (employmentType != "Salaried" && employmentType != "Self-Employed")
            {
                throw new InvalidCreditDataException("Invalid employment type");
            }
            if(monthlyIncome < 2000)
            {
                throw new InvalidCreditDataException("Invalid monthly income");
            }
            if(dues < 0)
            {
                throw new InvalidCreditDataException("Invalid credit dues");
            }
            if(creditScore < 300 || creditScore > 900)
            {
                throw new InvalidCreditDataException("Invalid credit score");
            }
            if(defaults < 0)
            {
                throw new InvalidCreditDataException("Invaid default count");
            }
            return true;
        }
        public static double calculateCreditLimit(double monthlyIncome, double dues, int creditScore, int defaults)
        {
            double debtRatio = dues / (monthlyIncome / 60);
            if(creditScore < 600 || defaults  >= 3 || debtRatio > 0.4)
            {
                return 50000;
            }
            else if(creditScore >= 750 && defaults == 0 && debtRatio < 0.25)
            {
                return 300000;
            }
            else
            {
                return 150000;
            }
        }
    }
    class UserInterface
    {
        static void Main()
        {
            try
            {
                System.Console.Write("Enter customer name: ");
                string name = Console.ReadLine();
                System.Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());
                System.Console.Write("Enter employment type: ");
                string employmentType = Console.ReadLine();
                System.Console.Write("Enter monthly income: ");
                double monthlyIncome = double.Parse(Console.ReadLine());
                System.Console.Write("Enter existing credit dues: ");
                double dues = double.Parse(Console.ReadLine());
                System.Console.Write("Enter credit score: ");
                int creditScore = int.Parse(Console.ReadLine());
                Console.Write("Enter number of loan defaults: ");
                int defaults = int.Parse(Console.ReadLine());

                CreditRiskProcessor.validateCustomerDetails(age, employmentType, monthlyIncome, dues, creditScore, defaults);
                double limit = CreditRiskProcessor.calculateCreditLimit(monthlyIncome, dues, creditScore, defaults);
                System.Console.WriteLine("Customer Name: " + name);
                System.Console.WriteLine("Approved Credit Limit: "+ limit);
            }
            catch(InvalidCreditDataException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}