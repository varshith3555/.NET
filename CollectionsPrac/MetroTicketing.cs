using System;
using System.Collections.Generic;

class MetroTicketing
{
    static void Main()
    {
        Queue<(TimeSpan entryTime, string ticketType)> q = new Queue<(TimeSpan, string)>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            TimeSpan entryTime = TimeSpan.Parse(Console.ReadLine());
            string ticketType = Console.ReadLine();
            q.Enqueue((entryTime, ticketType));
        }
        int count = CountRegularPeakTickets(q);
        Console.WriteLine(count);
    }

    static int CountRegularPeakTickets(Queue<(TimeSpan entryTime, string ticketType)> q)
    {
        int count = 0;
        TimeSpan start = new TimeSpan(8, 0, 0);
        TimeSpan end = new TimeSpan(10, 0, 0);
        while (q.Count > 0)
        {
            var item = q.Dequeue();

            if (item.ticketType == "Regular" &&
                item.entryTime >= start &&
                item.entryTime <= end)
            {
                count++;
            }
        }
        return count;
    }
}
