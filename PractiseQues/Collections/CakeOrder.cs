using System;
using System.Collections.Generic;
using System.Linq;

public class CakeOrder
{
    private Dictionary<string, double> orderMap = new Dictionary<string, double>();
    public void addOrderDetails(String orderld, double cakeCost)
    {
        orderMap[orderld] = cakeCost;
    }
    public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
    {
        return orderMap.Where (x => x.Value > cakeCost).ToDictionary(x => x.Key, x => x.Value);
    }
}

public class UserInterface1
{
    public static void Main()
    {
        CakeOrder c = new CakeOrder();
        System.Console.WriteLine("Enter number of cake orders to be added");
        int n = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter the cake order details (Order Id: CakeCost)");  
        for(int i = 1; i <= n; i++)
        {
            string? input = Console.ReadLine();
            string[] parts = input.Split(":");
            c.addOrderDetails(parts[0], double.Parse(parts[1]));
        }

        System.Console.WriteLine("Enter the cost to search the cake orders");
        double cost = double.Parse(Console.ReadLine()!);
 
        var orders = c.findOrdersAboveSpecifiedCost(cost);
        if (orders.Count > 0)
        {
            Console.WriteLine("Cake Orders above the specified cost");
            foreach(var item in orders)
            {
                Console.WriteLine($"Order ID: {item.Key}, Cake Cost: {item.Value}");
            }
        }
        else
        {
            Console.WriteLine("No cake orders found");
        }
    }
}