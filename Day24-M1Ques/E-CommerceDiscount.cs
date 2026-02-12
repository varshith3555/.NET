using System.Runtime.ConstrainedExecution;

namespace M1Ques
{
    abstract class DiscountPolicy
    {
        public abstract double GetFinalAmount(double amount);
    }
    class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if(amount >= 5000)
            {
                return amount * 0.90;
            }
            else
            {
                return amount * 0.95;
            }
        }
    }

    class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if(amount >= 2000)
            {
                return amount - 300;
            }
            else
            {
                return amount;
            }
        }
    }

    class DiscountPolicyMain
    {
        static void Main()
        {
            System.Console.WriteLine("Enter the purchase Amount");
            double amount = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Choose Discount Policy:");
            Console.WriteLine("1. Festival Discount");
            Console.WriteLine("2. Member Discount");

            int choice = int.Parse(Console.ReadLine()!);
            DiscountPolicy policy;
            if(choice == 1)
            {
                policy = new FestivalDiscount();
            }
            else if(choice == 2)
            {
                policy = new MemberDiscount();
            }
            else
            {
                System.Console.WriteLine("Invalid choice");
                return;
            }
            double finalAmount = policy.GetFinalAmount(amount);
            System.Console.WriteLine("Final Amount : "+ finalAmount);
        }
    }
}