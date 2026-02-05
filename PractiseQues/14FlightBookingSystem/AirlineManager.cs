using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightBookingSystem
{
    public class AirlineManager
    {
        private List<Flight> flights = new List<Flight>();
        private List<Booking> bookings = new List<Booking>();
        private int bookingIdCounter = 1;

        public void AddFlight(string number, string origin, string destination, DateTime depart, DateTime arrive, int seats, double price)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Flight number cannot be empty.");

            flights.Add(new Flight
            {
                FlightNumber = number,
                Origin = origin,
                Destination = destination,
                DepartureTime = depart,
                ArrivalTime = arrive,
                TotalSeats = seats,
                AvailableSeats = seats,
                TicketPrice = price
            });
        }

        public bool BookFlight(string flightNumber, string passenger, int seats, string seatClass)
        {
            var flight = flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
            if (flight == null)
                throw new Exception("Flight not found.");

            if (flight.AvailableSeats < seats)
                return false;

            double totalFare = flight.TicketPrice * seats;
            if (seatClass == "Business")
                totalFare *= 1.5;

            flight.AvailableSeats -= seats;
            bookings.Add(new Booking
            {
                BookingId = "BK" + bookingIdCounter++,
                FlightNumber = flightNumber,
                PassengerName = passenger,
                SeatsBooked = seats,
                TotalFare = totalFare,
                SeatClass = seatClass
            });

            return true;
        }

        public Dictionary<string, List<Flight>> GroupFlightsByDestination()
        {
            var grouped = new Dictionary<string, List<Flight>>();
            foreach (var flight in flights)
            {
                if (!grouped.ContainsKey(flight.Destination))
                    grouped[flight.Destination] = new List<Flight>();
                grouped[flight.Destination].Add(flight);
            }
            return grouped;
        }

        public List<Flight> SearchFlights(string origin, string destination, DateTime date)
        {
            return flights
                .Where(f => f.Origin == origin && f.Destination == destination && f.DepartureTime.Date == date.Date)
                .ToList();
        }

        public double CalculateTotalRevenue(string flightNumber)
        {
            return bookings.Where(b => b.FlightNumber == flightNumber).Sum(b => b.TotalFare);
        }
    }
}
