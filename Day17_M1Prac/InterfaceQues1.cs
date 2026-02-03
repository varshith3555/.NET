//using System;

//namespace HotelBillingApp
//{
//    public interface Room
//    {
//        public int calculateMembershipYears(int joiningYear)
//        {
//            return DateTime.Now.Year - joiningYear;
//        }
//    }
//    public class HotelRoom : Room
//    {
//        private string roomType;
//        private double ratePerNight;
//        private string guestName;

//        public HotelRoom(string roomType, double ratePerNight, string guestName)
//        {
//            this.roomType = roomType;
//            this.ratePerNight = ratePerNight;
//            this.guestName = guestName;
//        }

//        public string RoomType { get { return roomType; } }
//        public double RatePerNight { get { return ratePerNight; } }
//        public string GuestName { get { return guestName; } }

//        public double calculateTotalBill(int nightsStayed, int joiningYear)
//        {
//            double totalBill = nightsStayed * ratePerNight;
//            int membershipYears = calculateMembershipYears(joiningYear);

//            if (membershipYears > 3)
//            {
//                totalBill *= 0.9;

//            return Math.Round(totalBill);
//        }
//    }

//    public class UserInterface
//    {
//            public static void Main()
//            {
//                Console.WriteLine("Enter Deluxe Room Details:");
//                Console.Write("Guest Name: ");
//                string deluxeGuest = Console.ReadLine();

//                Console.Write("Rate per Night: ");
//                double deluxeRate = double.Parse(Console.ReadLine());

//                Console.Write("Nights Stayed: ");
//                int deluxeNights = int.Parse(Console.ReadLine());

//                Console.Write("Joining Year: ");
//                int deluxeJoiningYear = int.Parse(Console.ReadLine());

//                Console.WriteLine("Enter Suite Room Details:");
//                Console.Write("Guest Name: ");
//                string suiteGuest = Console.ReadLine();

//                Console.Write("Rate per Night: ");
//                double suiteRate = double.Parse(Console.ReadLine());

//                Console.Write("Nights Stayed: ");
//                int suiteNights = int.Parse(Console.ReadLine());

//                Console.Write("Joining Year: ");
//                int suiteJoiningYear = int.Parse(Console.ReadLine());

//                HotelRoom deluxeRoom = new HotelRoom("Deluxe", deluxeRate, deluxeGuest);
//                HotelRoom suiteRoom = new HotelRoom("Suite", suiteRate, suiteGuest);

//                int deluxeMembership = deluxeRoom.calculateMembershipYears(deluxeJoiningYear);
//                int suiteMembership = suiteRoom.calculateMembershipYears(suiteJoiningYear);

//                double deluxeBill = deluxeRoom.calculateTotalBill(deluxeNights, deluxeJoiningYear);
//                double suiteBill = suiteRoom.calculateTotalBill(suiteNights, suiteJoiningYear);

//                Console.WriteLine("Room Summary:");
//                Console.WriteLine($"Deluxe Room: {deluxeRoom.GuestName}, {deluxeRoom.RatePerNight} per night, Membership: {deluxeMembership} years");
//                Console.WriteLine($"Suite Room: {suiteRoom.GuestName}, {suiteRoom.RatePerNight} per night, Membership: {suiteMembership} years");

//                Console.WriteLine("Total Bill:");
//                Console.WriteLine($"For {deluxeRoom.GuestName} (Deluxe): {deluxeBill}");
//                Console.WriteLine($"For {suiteRoom.GuestName} (Suite): {suiteBill}");
//            }
//        }
//    }
//}
