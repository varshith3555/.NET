using System;
using System.Collections.Generic;

class BankStatement
{
    static void Main()
    {
        List<(string category, decimal amount)> txns = new List<(string, decimal)>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string category = Console.ReadLine();
            decimal amount = decimal.Parse(Console.ReadLine());
            txns.Add((category, amount));
        }

        Dictionary<string, decimal> result = CalculateSpend(txns);
        foreach (var item in result)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }

    static Dictionary<string, decimal> CalculateSpend(List<(string category, decimal amount)> txns)
    {
        Dictionary<string, decimal> spendByCategory = new Dictionary<string, decimal>();

        foreach (var txn in txns)
        {
            if (txn.amount < 0)
            {
                decimal positiveAmount = Math.Abs(txn.amount);

                if (spendByCategory.ContainsKey(txn.category))
                {
                    spendByCategory[txn.category] += positiveAmount;
                }
                else
                {
                    spendByCategory[txn.category] = positiveAmount;
                }
            }
        }
        return spendByCategory;
    }
}
