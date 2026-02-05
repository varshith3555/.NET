using System.Runtime.InteropServices;

public class HotelManager
{
    private Dictionary<int, Room> rooms = new Dictionary<int, Room>();
    public void AddBook(int roomNumber, string type, double price)
    {
        if (!rooms.ContainsKey(roomNumber))
        {
            rooms.Add(roomNumber, new Room
            {
                RoomNumber = roomNumber,
                RoomType = type,
                RatePerNight = price,
                IsAvailable = true
            });
        }
    }
    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        return rooms.Values.Where(e => e.IsAvailable).GroupBy(e => e.RoomType).ToDictionary(f => f.Key, g => g.ToList());
    }
    public bool BookRoom(int roomNumber, int nights)
    {
        if(rooms.ContainsKey(roomNumber) && rooms[roomNumber].IsAvailable)
        {
            double totalCost = rooms[roomNumber].RatePerNight * nights;
            rooms[roomNumber].IsAvailable = false;
            System.Console.WriteLine(totalCost);
            return true;
        }
        return false;
    }
    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        return rooms.Values.Where(e => e.IsAvailable && e.RatePerNight >= min && e.RatePerNight <= max).ToList();
    }
}
