using System;
using System.Collections.Generic;

class ECommerceCartConsolidation
{
    static void Main()
    {
        List<(string sku, int qty)> scans = new List<(string sku, int qty)>();
        System.Console.WriteLine("Enter number of scans");
        int n = int.Parse(Console.ReadLine()!);

        for(int i = 0; i < n; i++)
        {
            System.Console.WriteLine("Enter SKU");
            string sku = Console.ReadLine()!;
            System.Console.WriteLine("Enter Quantity");
            int quantity = int.Parse(Console.ReadLine()!);

            scans.Add((sku, quantity));
        }
        Dictionary<string,int> skuQty = ConsolidateCart(scans);
        foreach(var i in skuQty)
        {
            System.Console.WriteLine(i.Key + " : "+ i.Value);
        }
    }

    static Dictionary<string, int> ConsolidateCart(List<(string sku, int qty)> scans)
    {
        Dictionary<string, int> res = new Dictionary<string, int>();
        foreach(var i in scans)
        {
            if(i.qty <= 0)
            {
                continue;
            }
            if (res.ContainsKey(i.sku))
            {
                res[i.sku] += i.qty;
            }
            else
            {
                res[i.sku] = i.qty;
            }
        }
        return res;
    }
}