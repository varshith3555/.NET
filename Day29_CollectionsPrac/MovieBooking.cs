using System;
using System.Collections.Generic;

class MovieBooking
{
    static void Main()
    {
        int n = 5;
        List<int> alreadyBooked = new List<int> { 2, 4 };
        int requestCount = 4;

        SortedSet<int> available = new SortedSet<int>();

        for (int i = 1; i <= n; i++)
            available.Add(i);

        foreach (int seat in alreadyBooked)
            available.Remove(seat);

        List<int> allocatedSeats = new List<int>();

        for (int i = 0; i < requestCount; i++)
        {
            if (available.Count > 0)
            {
                int seat = available.Min;
                allocatedSeats.Add(seat);
                available.Remove(seat);
            }
            else
            {
                allocatedSeats.Add(-1);
            }
        }

        foreach (var seat in allocatedSeats)
        {
            Console.WriteLine(seat);
        }
    }
}
