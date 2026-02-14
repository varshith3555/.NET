using System;
using System.Collections.Generic;

class LogAnalyzer
{
    static void Main()
    {
        List<string> codes = new List<string>
        {
            "E02","E01","E02","E01","E03"
        };

        string result = MostFrequentCode(codes);

        Console.WriteLine(result);
    }

    static string MostFrequentCode(List<string> codes)
    {
        Dictionary<string, int> freq = new Dictionary<string, int>();

        foreach (var code in codes)
        {
            if (freq.ContainsKey(code))
                freq[code]++;
            else
                freq[code] = 1;
        }

        string result = "";
        int max = 0;

        foreach (var pair in freq)
        {
            if (pair.Value > max ||
               (pair.Value == max && string.Compare(pair.Key, result) < 0))
            {
                max = pair.Value;
                result = pair.Key;
            }
        }

        return result;
    }
}
