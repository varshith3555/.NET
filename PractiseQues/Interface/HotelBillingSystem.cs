public interface Room
{
    double calculateTotalBill(int nightsStayed, int joiningYear);

    int calculateMembershipYears(int joiningYear)
    {
        int curr = DateTime.Now.Year;
        return curr - joiningYear;
    }
}
class HotelRoom : Room
{
    private string roomType;
    private double ratePerNight;
    private string guestName;

    public HotelRoom(string roomType, double ratePerNight, string guestName)
    {
        this.roomType = roomType;
        this.ratePerNight = ratePerNight;
        this.guestName = guestName;
    }

    public string RoomType { get { return roomType; } }
    public double RatePerNight { get { return ratePerNight; } }
    public string GuestName { get { return guestName; } }

    public int calculateMembershipYears(int joiningYear)
    {
    int curr = DateTime.Now.Year;
    return curr - joiningYear;
    }

    public double calculateTotalBill(int nightsStayed, int joiningYear)
    {
        double Total = nightsStayed * ratePerNight;

        int membershipyears = calculateMembershipYears(joiningYear);
        if (membershipyears > 3)
        {
            Total = Total * 0.90;
        }

        return Math.Round(Total);
    }
}
class UserInterface1
{
    public static void Main()
    {
        // Deluxe Room
        Console.WriteLine("Enter Deluxe Room Details:");
        Console.Write("Guest Name: ");
        string deluxeGuest = Console.ReadLine()!;
        Console.Write("Rate per Night: ");
        double deluxeRate = double.Parse(Console.ReadLine()!);
        Console.Write("Nights Stayed: ");
        int deluxeNights = int.Parse(Console.ReadLine()!);
        Console.Write("Joining Year: ");
        int deluxeJoinYear = int.Parse(Console.ReadLine()!);
        
        HotelRoom dr = new HotelRoom("Deluxe", deluxeRate, deluxeGuest);
        int delMembershipyears = dr.calculateMembershipYears(deluxeJoinYear);
        double deluxeBill = dr.calculateTotalBill(deluxeNights, deluxeJoinYear);

        // Suite Room
        Console.WriteLine("Enter Suite Room Details:");
        Console.Write("Guest Name: ");
        string suiteGuest = Console.ReadLine()!;
        Console.Write("Rate per Night: ");
        double suiteRate = double.Parse(Console.ReadLine()!);
        Console.Write("Nights Stayed: ");
        int suiteNights = int.Parse(Console.ReadLine()!);
        Console.Write("Joining Year: ");
        int suiteJoinYear = int.Parse(Console.ReadLine()!);

        HotelRoom sr = new HotelRoom("Suite", suiteRate, suiteGuest);
        int suiteMembershipYears = dr.calculateMembershipYears(suiteJoinYear);
        double suiteBill = sr.calculateTotalBill(suiteNights, suiteJoinYear);

        Console.WriteLine("Room Summary:");
        Console.WriteLine($"Deluxe Room: {dr.GuestName}, {dr.RatePerNight} per night, Membership: {delMembershipyears} years");
        Console.WriteLine($"Suite Room: {sr.GuestName}, {sr.RatePerNight} per night, Membership: {suiteMembershipYears} years");

        Console.WriteLine("Total Bill:");
        Console.WriteLine($"For {dr.GuestName} (Deluxe): {deluxeBill:F1}");
        Console.WriteLine($"For {sr.GuestName} (Suite): {suiteBill:F1}");
    }
}