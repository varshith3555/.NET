using System;
using System.Collections.Generic;

class MergeTickets
{
    static void Main()
    {
        List<int> a = new List<int>();
        List<int> b = new List<int>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            a.Add(int.Parse(Console.ReadLine()));
        }
        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            b.Add(int.Parse(Console.ReadLine()));
        }

        List<int> merged = MergeSortedLists(a, b);
        foreach (int val in merged)
        {
            Console.Write(val + " ");
        }
    }

    static List<int> MergeSortedLists(List<int> a, List<int> b)
    {
        List<int> merged = new List<int>();

        int i = 0, j = 0;
        while (i < a.Count && j < b.Count)
        {
            if (a[i] <= b[j])
            {
                merged.Add(a[i]);
                i++;
            }
            else
            {
                merged.Add(b[j]);
                j++;
            }
        }
        while (i < a.Count)
        {
            merged.Add(a[i]);
            i++;
        }
        while (j < b.Count)
        {
            merged.Add(b[j]);
            j++;
        }
        return merged;
    }
}
