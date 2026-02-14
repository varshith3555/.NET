using System;

namespace FlightBookingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Flight Booking System");
            var airlineManager = new AirlineManager();

            // Add flights
            DateTime today = DateTime.Now;
            airlineManager.AddFlight("AA101", "New York", "Los Angeles", today.AddHours(8), today.AddHours(11), 150, 250.00);
            airlineManager.AddFlight("AA102", "New York", "Los Angeles", today.AddHours(14), today.AddHours(17), 180, 250.00);
            airlineManager.AddFlight("UA201", "New York", "Chicago", today.AddHours(10), today.AddHours(12), 120, 150.00);
            airlineManager.AddFlight("DL301", "Los Angeles", "Chicago", today.AddHours(12), today.AddHours(15), 160, 200.00);
            airlineManager.AddFlight("SW401", "New York", "Las Vegas", today.AddHours(9), today.AddHours(12), 200, 180.00);

            // Book flights
            Console.WriteLine("Booking Flights:");
            bool book1 = airlineManager.BookFlight("AA101", "John Doe", 2, "Economy");
            Console.WriteLine($"Book 2 Economy seats on AA101: {(book1 ? "Success" : "Failed")}");

            bool book2 = airlineManager.BookFlight("AA101", "Jane Smith", 1, "Business");
            Console.WriteLine($"Book 1 Business seat on AA101: {(book2 ? "Success" : "Failed")}");

            bool book3 = airlineManager.BookFlight("UA201", "Bob Johnson", 3, "Economy");
            Console.WriteLine($"Book 3 Economy seats on UA201: {(book3 ? "Success" : "Failed")}");

            bool book4 = airlineManager.BookFlight("DL301", "Alice Brown", 2, "Economy");
            Console.WriteLine($"Book 2 Economy seats on DL301: {(book4 ? "Success" : "Failed")}");

            // Search flights
            Console.WriteLine("\nSearching Flights (NY to LA):");
            var searchResults = airlineManager.SearchFlights("New York", "Los Angeles", today);
            foreach (var flight in searchResults)
            {
                Console.WriteLine($"{flight.FlightNumber}: {flight.Origin} → {flight.Destination}");
                Console.WriteLine($"  Departure: {flight.DepartureTime:yyyy-MM-dd HH:mm} | Arrival: {flight.ArrivalTime:yyyy-MM-dd HH:mm}");
                Console.WriteLine($"  Available: {flight.AvailableSeats}/{flight.TotalSeats} | Price: ${flight.TicketPrice}");
            }

            // Display flights by destination
            Console.WriteLine("\nFlights by Destination:");
            var grouped = airlineManager.GroupFlightsByDestination();
            foreach (var dest in grouped)
            {
                Console.WriteLine($"\n{dest.Key}:");
                foreach (var flight in dest.Value)
                {
                    Console.WriteLine($"  {flight.FlightNumber}: {flight.DepartureTime:yyyy-MM-dd HH:mm} | Available: {flight.AvailableSeats} seats");
                }
            }

            // Display flight revenues
            Console.WriteLine("\nFlight Revenue:");
            var allFlights = airlineManager.GroupFlightsByDestination();
            foreach (var dest in allFlights)
            {
                foreach (var flight in dest.Value)
                {
                    double revenue = airlineManager.CalculateTotalRevenue(flight.FlightNumber);
                    Console.WriteLine($"{flight.FlightNumber}: ${revenue:F2}");
                }
            }
        }
    }
}
