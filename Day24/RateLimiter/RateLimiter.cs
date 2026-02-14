using System;
using System.Collections.Generic;

namespace RateLimiter;

class RateLimiter
{
    private Dictionary<string, Queue<DateTime>> requests =
        new Dictionary<string, Queue<DateTime>>();

    private object lockObj = new object();

    private const int MAX_REQUESTS = 5;
    private static TimeSpan WINDOW = TimeSpan.FromSeconds(10);

    public bool AllowRequest(string clientId, DateTime now)
    {
        lock (lockObj)
        {
            if (!requests.ContainsKey(clientId))
                requests[clientId] = new Queue<DateTime>();

            var queue = requests[clientId];

            // Remove old requests
            while (queue.Count > 0 && now - queue.Peek() > WINDOW)
            {
                queue.Dequeue();
            }

            // Check limit
            if (queue.Count >= MAX_REQUESTS)
                return false;

            // Allow request
            queue.Enqueue(now);
            return true;
        }
    }
}
