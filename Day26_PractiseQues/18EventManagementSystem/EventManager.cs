namespace _18EventManagementSystem
{
    public class EventManager
    {
        private List<Event> events;
        private List<Attendee> attendees;
        private List<Ticket> tickets;
        private int eventIdCounter;
        private int attendeeIdCounter;
        private int ticketCounter;

        public EventManager()
        {
            events = new List<Event>();
            attendees = new List<Attendee>();
            tickets = new List<Ticket>();
            eventIdCounter = 1;
            attendeeIdCounter = 1;
            ticketCounter = 1000;
        }

        public void CreateEvent(string name, string type, DateTime date, string venue, int capacity, double price)
        {
            events.Add(new Event
            {
                EventId = eventIdCounter++,
                EventName = name,
                EventType = type,
                EventDate = date,
                Venue = venue,
                TotalCapacity = capacity,
                TicketsSold = 0,
                TicketPrice = price
            });
            Console.WriteLine($"Event '{name}' created successfully!");
        }

        public bool BookTicket(int eventId, int attendeeId, string seatNumber)
        {
            var eventItem = events.FirstOrDefault(e => e.EventId == eventId);
            if (eventItem == null)
            {
                Console.WriteLine($"Event with id {eventId} not found!");
                return false;
            }

            if (eventItem.TicketsSold >= eventItem.TotalCapacity)
            {
                Console.WriteLine($"Event {eventItem.EventName} is fully booked!");
                return false;
            }

            if (tickets.Any(t => t.EventId == eventId && t.SeatNumber == seatNumber))
            {
                Console.WriteLine($"Seat {seatNumber} is already booked!");
                return false;
            }

            var attendee = attendees.FirstOrDefault(a => a.AttendeeId == attendeeId);
            if (attendee == null)
            {
                attendee = new Attendee
                {
                    AttendeeId = attendeeId,
                    Name = $"Attendee{attendeeId}",
                    Email = string.Empty,
                    Phone = string.Empty
                };
                attendees.Add(attendee);
                if (attendeeIdCounter <= attendeeId)
                {
                    attendeeIdCounter = attendeeId + 1;
                }
            }

            tickets.Add(new Ticket
            {
                TicketNumber = $"TKT{ticketCounter++}",
                EventId = eventId,
                AttendeeId = attendeeId,
                PurchaseDate = DateTime.Now,
                SeatNumber = seatNumber
            });

            eventItem.TicketsSold++;
            attendee.RegisteredEvents.Add(eventId);

            Console.WriteLine($"Ticket booked successfully for attendee {attendeeId} at seat {seatNumber}!");
            return true;
        }

        public Dictionary<string, List<Event>> GroupEventsByType()
        {
            return events.GroupBy(e => e.EventType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Event> GetUpcomingEvents(int days)
        {
            var targetDate = DateTime.Now.AddDays(days);
            return events.Where(e => e.EventDate <= targetDate && e.EventDate >= DateTime.Now)
                .OrderBy(e => e.EventDate)
                .ToList();
        }

        public double CalculateEventRevenue(int eventId)
        {
            var eventItem = events.FirstOrDefault(e => e.EventId == eventId);
            if (eventItem == null)
            {
                Console.WriteLine($"Event with id {eventId} not found!");
                return 0;
            }

            return eventItem.TicketsSold * eventItem.TicketPrice;
        }

    }
}
