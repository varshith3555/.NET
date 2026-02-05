using System;

namespace MovieTheaterBooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Movie Theater Booking System");

            var theaterManager = new TheaterManager();

            // Add screenings
            theaterManager.AddScreening("Avengers: Endgame", new DateTime(2026, 2, 5, 18, 0, 0), "Screen 1", 100, 12.50);
            theaterManager.AddScreening("Avengers: Endgame", new DateTime(2026, 2, 5, 20, 30, 0), "Screen 2", 80, 12.50);
            theaterManager.AddScreening("Inception", new DateTime(2026, 2, 5, 19, 0, 0), "Screen 3", 120, 11.00);
            theaterManager.AddScreening("Inception", new DateTime(2026, 2, 5, 21, 30, 0), "Screen 1", 100, 11.00);
            theaterManager.AddScreening("The Dark Knight", new DateTime(2026, 2, 6, 17, 30, 0), "Screen 4", 90, 12.00);

            // Book tickets
            Console.WriteLine("Booking Tickets:");

            bool result1 = theaterManager.BookTickets("Avengers: Endgame", new DateTime(2026, 2, 5, 18, 0, 0), 25);
            Console.WriteLine($"Book 25 tickets for Avengers (6:00 PM): {(result1 ? "Success" : "Failed")}");

            bool result2 = theaterManager.BookTickets("Avengers: Endgame", new DateTime(2026, 2, 5, 18, 0, 0), 40);
            Console.WriteLine($"Book 40 tickets for Avengers (6:00 PM): {(result2 ? "Success" : "Failed")}");

            bool result3 = theaterManager.BookTickets("Inception", new DateTime(2026, 2, 5, 19, 0, 0), 50);
            Console.WriteLine($"Book 50 tickets for Inception (7:00 PM): {(result3 ? "Success" : "Failed")}");

            bool result4 = theaterManager.BookTickets("The Dark Knight", new DateTime(2026, 2, 6, 17, 30, 0), 85);
            Console.WriteLine($"Book 85 tickets for The Dark Knight: {(result4 ? "Success" : "Failed")}");

            bool result5 = theaterManager.BookTickets("The Dark Knight", new DateTime(2026, 2, 6, 17, 30, 0), 10);
            Console.WriteLine($"Book 10 more tickets for The Dark Knight: {(result5 ? "Success" : "Failed")}");

            // Display total revenue
            Console.WriteLine($"\nTotal Revenue: ${theaterManager.CalculateTotalRevenue():F2}");

            // Display screenings grouped by movie
            Console.WriteLine("\nScreenings by Movie:");
            var grouped = theaterManager.GroupScreeningsByMovie();
            foreach(var movie in grouped)
            {
                Console.WriteLine($"\n{movie.Key}:");
                foreach(var screening in movie.Value)
                {
                    int available = screening.TotalSeats - screening.BookedSeats;
                    Console.WriteLine($"  Screen {screening.ScreenNumber} - {screening.ShowTime:yyyy-MM-dd HH:mm}");
                    Console.WriteLine($"    Booked: {screening.BookedSeats}/{screening.TotalSeats} | Available: {available} | Price: ${screening.TicketPrice}");
                }
            }

            // Display available screenings
            Console.WriteLine("\nAvailable Screenings (at least 30 seats):");
            var available_screenings = theaterManager.GetAvailableScreenings(30);
            foreach(var screening in available_screenings)
            {
                int avail = screening.TotalSeats - screening.BookedSeats;
                Console.WriteLine($"{screening.MovieTitle} - {screening.ShowTime:yyyy-MM-dd HH:mm} | Available: {avail} seats");
            }
        }
    }
}
