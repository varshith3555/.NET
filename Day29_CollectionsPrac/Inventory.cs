using System;
using System.Collections.Generic;

class Inventory
{
    static void Main()
    {
        List<string> serials = new List<string>
        {
            "S1","S2","S1","S3","S2","S2"
        };

        List<string> duplicates = GetDuplicates(serials);

        foreach (var d in duplicates)
        {
            Console.WriteLine(d);
        }
    }

    static List<string> GetDuplicates(List<string> serials)
    {
        HashSet<string> seen = new HashSet<string>();
        HashSet<string> added = new HashSet<string>();
        List<string> duplicates = new List<string>();

        foreach (var s in serials)
        {
            if (!seen.Add(s))
            {
                if (!added.Contains(s))
                {
                    duplicates.Add(s);
                    added.Add(s);
                }
            }
        }

        return duplicates;
    }
}
