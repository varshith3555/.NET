using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create HotelManager object
        HotelManager hotel = new HotelManager();

        // Add different room types with prices
        hotel.AddBook(101, "Single", 1500);
        hotel.AddBook(102, "Double", 2500);
        hotel.AddBook(103, "Suite", 5000);
        hotel.AddBook(104, "Single", 1800);
        hotel.AddBook(105, "Double", 3000);

        // Display available rooms grouped by type
        Console.WriteLine("🏨 Available Rooms Grouped by Type:");
        Dictionary<string, List<Room>> groupedRooms = hotel.GroupRoomsByType();

        foreach (var group in groupedRooms)
        {
            Console.WriteLine($"\nRoom Type: {group.Key}");
            foreach (var room in group.Value)
            {
                Console.WriteLine(
                    $"Room No: {room.RoomNumber}, Price: {room.RatePerNight}"
                );
            }
        }

        // Book a room for specific nights
        Console.WriteLine("\n📌 Booking Room 102 for 3 nights:");
        bool isBooked = hotel.BookRoom(102, 3);

        if (!isBooked)
        {
            Console.WriteLine("Room booking failed.");
        }

        // Find rooms within budget
        Console.WriteLine("\n💰 Available Rooms Between 1500 and 3000:");
        List<Room> budgetRooms = hotel.GetAvailableRoomsByPriceRange(1500, 3000);

        foreach (var room in budgetRooms)
        {
            Console.WriteLine(
                $"Room No: {room.RoomNumber}, Type: {room.RoomType}, Price: {room.RatePerNight}"
            );
        }
    }
}
