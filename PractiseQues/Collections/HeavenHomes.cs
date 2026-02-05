public class Apartment
{
    private Dictionary<string, double> apartmentDetailsMap = new Dictionary<string, double>();
    public Dictionary<string, double> ApartmentDetailsMap
    {
        get{return apartmentDetailsMap;}
        set{apartmentDetailsMap = value;}
    }
    public void addApartmentDetails(string apartmentNumber, double rent)
    {
        apartmentDetailsMap[apartmentNumber] = rent;
    }
    public double findTotalRentOfApartmentsInTheGivenRange(double minimumRent, double maximumRent)
    {
        return apartmentDetailsMap
        .Where (x => x.Value >= minimumRent && x.Value <= maximumRent)
        .Select(x => x.Value)
        .Sum();
    }
}
public class UserInterface3
{
    public static void Main()
    {
        Apartment a = new Apartment();
        System.Console.WriteLine("Enter number of details to be added");
        int n = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter the details (Apartment number: Rent)");
        for(int i = 0; i < n; i++)
        {
            string? ApNum = Console.ReadLine();
            string[] parts = ApNum.Split(":");
            a.addApartmentDetails(parts[0], double.Parse(parts[1]));
        }

        System.Console.WriteLine("Enter the range to filter the details");
        double minRent = double.Parse(Console.ReadLine()!);
        double maxRent = double.Parse(Console.ReadLine()!);
        
        var tRent = a.findTotalRentOfApartmentsInTheGivenRange(minRent, maxRent);
        if(tRent > 0)
        {
            System.Console.WriteLine("Total Rent in the range" + minRent + " to "+ maxRent + "USD:" + tRent);
        }
        else
        {
            System.Console.WriteLine("No apartments found in this range");
        }
    }
}
