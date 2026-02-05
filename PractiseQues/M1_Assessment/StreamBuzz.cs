using System;
using System.Collections.Generic;

public class CreatorStats
{
    public string? CreatorName { get; set; }
    public double[]? WeeklyLikes{get;set;} =new double[4];

}
public class StreamBuzz
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public static void Main(string[] args)
    {
        int input;
        do
        {
            System.Console.WriteLine("1. Register Creator");
            System.Console.WriteLine("2. Show Top Posts");
            System.Console.WriteLine("3. Calculate Average Likes");
            System.Console.WriteLine("4. Exit");
            System.Console.WriteLine("Enter your choice:");
            input = int.Parse(Console.ReadLine()!);
            CreatorStats creator = new CreatorStats();
            if (input == 1)
            {
                System.Console.WriteLine("Enter Creator Name:");
                creator.CreatorName = Console.ReadLine();
                System.Console.WriteLine("Enter weekly like(Week 1 to 4):");
                for (int i = 0; i < creator.WeeklyLikes!.Length; i++)
                {
                    creator.WeeklyLikes![i] = double.Parse(Console.ReadLine()!);
                }
                StreamBuzz.RegisterCreator(creator);
                System.Console.WriteLine("Creator registered successfully");
            }
            else if (input == 2)
            {
                System.Console.WriteLine("Enter like threshold:");
                double likeThreshold = double.Parse(Console.ReadLine()!);
                var res = StreamBuzz.GetTopPostCounts(EngagementBoard, likeThreshold);
                if (res.Count>0)
                {
                    foreach (var item in res)
                    {
                        System.Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
                else
                {
                    System.Console.WriteLine("No top-performing posts this week");
                }

            }
            else if (input == 3)
            {
                StreamBuzz.CalculateAverageLikes();
            }
            else if (input == 4)
            {

            }
            else
            {
                System.Console.WriteLine("Invalid Input");
            }
        } while (input != 4);
        System.Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
    }
    public static void RegisterCreator(CreatorStats record)
    {
        if (record != null)
        {
            EngagementBoard.Add(record);
        }
    }
    public static Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        
        foreach (var item in records)
        {
            int count = 0;
            for (int i = 0; i < item.WeeklyLikes!.Length; i++)
            {
                if (item.WeeklyLikes[i] >= likeThreshold)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                result.Add(item.CreatorName!, count);
            }
        }
        return result;
    }
    public static void CalculateAverageLikes()
    {
        int count = 0;
        double sum = 0;
        foreach (var item in EngagementBoard)
        {
            for (int i = 0; i < item.WeeklyLikes!.Length; i++)
            {
                sum += item.WeeklyLikes[i];
                count++;
            }
        }
        double result = sum / count;
        System.Console.WriteLine("Overall average weekly likes:" + result);
    }
}