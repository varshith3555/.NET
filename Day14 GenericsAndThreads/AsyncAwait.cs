using System;
using System.Collections.Generic;
using System.Text;


namespace MyConsoleApp.Day14_GenericsAndThreads
{
    public class Async
    {
        public async Task AsyncMethod()
        {
            Console.WriteLine("Task started");
            await Task.Delay(3000); // Non-blocking delay
            Console.WriteLine("Task completed after 3 seconds");
        }

        public async Task<string> FetchDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                return response;
            }
        }
        public static async Task Main(string[] args)
        {
            Async a = new Async();
            await a.AsyncMethod();
            string data = await a.FetchDataAsync("https://jsonplaceholder.typicode.com/posts/1/comments");
            Console.WriteLine(data);


        }
    }
}
