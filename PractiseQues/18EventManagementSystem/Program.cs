namespace _18EventManagementSystem
{
    class Program
    {
        static void Main()
        {
            EventManager manager = new EventManager();

            // Create events
            manager.CreateEvent("Tech Conference 2026", "Conference", DateTime.Now.AddDays(30), "Convention Center", 500, 99.99);
            manager.CreateEvent("Rock Concert", "Concert", DateTime.Now.AddDays(15), "Grand Arena", 1000, 59.99);
            manager.CreateEvent("C# Workshop", "Workshop", DateTime.Now.AddDays(7), "Tech Hub", 50, 149.99);

            // Book tickets
            manager.BookTicket(1, 1, "A101");
            manager.BookTicket(1, 2, "A102");
            manager.BookTicket(2, 1, "B201");
            manager.BookTicket(3, 3, "C001");


            // Group events by type
            var eventsByType = manager.GroupEventsByType();
            foreach (var group in eventsByType)
            {
                Console.WriteLine($"\nType: {group.Key}");
                foreach (var evt in group.Value)
                {
                    Console.WriteLine($"  - {evt.EventName} ({evt.TotalCapacity} capacity)");
                }
            }

            // Get upcoming events in 20 days
            var upcomingEvents = manager.GetUpcomingEvents(20);
            foreach (var evt in upcomingEvents)
            {
                Console.WriteLine($"{evt.EventName} on {evt.EventDate:yyyy-MM-dd}");
            }

            // Calculate event revenues
            for (int i = 1; i <= 3; i++)
            {
                double revenue = manager.CalculateEventRevenue(i);
                Console.WriteLine($"Event {i} Revenue: ${revenue}");
            }
        }
    }
}
