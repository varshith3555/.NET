using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTheaterBooking
{
    internal class TheaterManager
    {
        private List<MovieScreening> screenings = new List<MovieScreening>();

        // Adds new screening
        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            if(string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Movie title cannot be empty.");
            if(seats <= 0)
                throw new ArgumentException("Total seats must be greater than 0.");
            if(price < 0)
                throw new ArgumentException("Ticket price cannot be negative.");

            screenings.Add(new MovieScreening
            {
                MovieTitle = title,
                ShowTime = time,
                ScreenNumber = screen,
                TotalSeats = seats,
                BookedSeats = 0,
                TicketPrice = price
            });
        }

        // Books tickets if available seats
        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            var screening = screenings.FirstOrDefault(s => 
                s.MovieTitle == movieTitle && s.ShowTime == showTime);

            if(screening == null)
                throw new Exception("Screening not found.");

            int availableSeats = screening.TotalSeats - screening.BookedSeats;

            if(availableSeats >= tickets)
            {
                screening.BookedSeats += tickets;
                return true;
            }

            return false;
        }

        // Groups screenings by movie title
        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            var grouped = new Dictionary<string, List<MovieScreening>>();
            foreach(var screening in screenings)
            {
                if(!grouped.ContainsKey(screening.MovieTitle))
                    grouped[screening.MovieTitle] = new List<MovieScreening>();
                grouped[screening.MovieTitle].Add(screening);
            }
            return grouped;
        }

        // Calculates total revenue from all bookings
        public double CalculateTotalRevenue()
        {
            return screenings.Sum(s => s.BookedSeats * s.TicketPrice);
        }

        // Returns screenings with at least minSeats available
        public List<MovieScreening> GetAvailableScreenings(int minSeats)
        {
            return screenings
                .Where(s => (s.TotalSeats - s.BookedSeats) >= minSeats)
                .ToList();
        }
    }
}
