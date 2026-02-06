namespace GymStream{

    class Program
    {
        static void Main(string[] args)
        {
            Membership member = new Membership();

            // TODO: Wrap the following in a Try-Catch block
            try{
                Console.WriteLine("Enter membership tier:");
                member.Tier = Console.ReadLine();

                Console.WriteLine("Enter duration:");
                member.DurationInMonths = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter monthly price:");
                member.BasePricePerMonth = double.Parse(Console.ReadLine()!);

                // TODO: Call validation and display result/price
                if (member.ValidateEnrollment())
                {
                    double bill = member.CalculateTotalBill();
                    System.Console.WriteLine("\nEnrollment Successful!");
                    System.Console.WriteLine($"Total Bill Amount: ₹{bill:F2}");
                }
            }
            catch(InvalidTierException e){
                System.Console.WriteLine(e.Message);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }

}