namespace RateLimiter;

class Program2
{
    static void Main()
    {
        RateLimiter limiter = new RateLimiter();
        string client = "client1";

        for (int i = 1; i <= 6; i++)
        {
            Console.WriteLine(limiter.AllowRequest(client, DateTime.Now));
        }
    }
}
