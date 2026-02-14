using System.Collections.Generic;

class TicketBooking
{
    private readonly Dictionary<int, Seat> seats = new Dictionary<int, Seat>();
    private readonly object lockObj = new object();

    public TicketBooking()
    {
        seats[1] = new Seat(1);
    }

    public bool BookSeat(int seatNo, string userId)
    {
        lock (lockObj)
        {
            if (!seats.ContainsKey(seatNo))
                return false;

            if (seats[seatNo].IsBooked)
                return false;

            seats[seatNo].IsBooked = true;
            return true;
        }
    }
}

    public class Seat
    {
        public int SeatNo { get; }
        public bool IsBooked { get; set; }

        public Seat(int seatNo)
        {
            SeatNo = seatNo;
            IsBooked = false;
        }
    }
