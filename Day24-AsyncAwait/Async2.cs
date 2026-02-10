using System;
using System.Threading.Tasks;

class Program2
{
    static async Task Main()
    {
        Console.WriteLine("A");
        await PrintAfterDelayAsync();
        Console.WriteLine("C");
    }

    static async Task PrintAfterDelayAsync()
    {
        Console.WriteLine("B1");
        await Task.Delay(500);
        Console.WriteLine("B2");
    }
}