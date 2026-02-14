using System;
using System.Collections.Generic;

class Leaderboard
{
    static void Main()
    {
        List<(string name, int score)> players = new List<(string, int)>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string name = Console.ReadLine();
            int score = int.Parse(Console.ReadLine());
            players.Add((name, score));
        }
        int k = int.Parse(Console.ReadLine());

        List<(string name, int score)> topK = GetTopK(players, k);
        foreach (var player in topK)
        {
            Console.WriteLine(player.name + " " + player.score);
        }
    }

    static List<(string name, int score)> GetTopK(List<(string name, int score)> players, int k)
    {
        players.Sort((a, b) =>
        {
            if (b.score != a.score)
                return b.score.CompareTo(a.score);
            else
                return a.name.CompareTo(b.name);
        });

        List<(string name, int score)> result = new List<(string, int)>();
        for (int i = 0; i < k && i < players.Count; i++)
        {
            result.Add(players[i]);
        }
        return result;
    }
}
