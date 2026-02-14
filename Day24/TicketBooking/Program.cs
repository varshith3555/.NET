using System;
using System.Threading;

class Program3
{
    static void Main()
    {
        TicketBooking booking = new TicketBooking();

        Thread t1 = new Thread(() =>
            Console.WriteLine(booking.BookSeat(1, "UserA"))
        );

        Thread t2 = new Thread(() =>
            Console.WriteLine(booking.BookSeat(1, "UserB"))
        );

        t1.Start();
        t2.Start();
    }
}
