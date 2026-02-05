using System;
using System.Collections.Generic;

namespace OnlineFoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Online Food Delivery System");
            var deliveryManager = new DeliveryManager();

            // Add restaurants
            deliveryManager.AddRestaurant("Pizzeria Palace", "Italian", "Downtown", 2.50);
            deliveryManager.AddRestaurant("Sushi Express", "Japanese", "Midtown", 3.00);
            deliveryManager.AddRestaurant("Curry House", "Indian", "Uptown", 2.00);
            deliveryManager.AddRestaurant("Taco Fiesta", "Mexican", "Eastside", 1.50);
            deliveryManager.AddRestaurant("Dragon Wok", "Chinese", "Downtown", 2.50);

            // Add food items
            deliveryManager.AddFoodItem(6001, "Margherita Pizza", "Pizza", 12.99);
            deliveryManager.AddFoodItem(6001, "Pepperoni Pizza", "Pizza", 14.99);
            deliveryManager.AddFoodItem(6002, "Salmon Roll", "Sushi", 10.50);
            deliveryManager.AddFoodItem(6002, "Tuna Roll", "Sushi", 9.50);
            deliveryManager.AddFoodItem(6003, "Butter Chicken", "Curry", 11.99);
            deliveryManager.AddFoodItem(6003, "Tikka Masala", "Curry", 12.99);
            deliveryManager.AddFoodItem(6004, "Beef Tacos", "Tacos", 8.99);
            deliveryManager.AddFoodItem(6005, "Fried Rice", "Rice Dish", 9.99);

            // Place orders
            Console.WriteLine("Placing Orders:");
            var order1Items = new List<int> { 7001, 7002 };
            bool order1 = deliveryManager.PlaceOrder(1, order1Items);
            Console.WriteLine($"Order 1 (Pizzas): {(order1 ? "Placed" : "Failed")}");

            var order2Items = new List<int> { 7003, 7004 };
            bool order2 = deliveryManager.PlaceOrder(2, order2Items);
            Console.WriteLine($"Order 2 (Sushi): {(order2 ? "Placed" : "Failed")}");

            var order3Items = new List<int> { 7005, 7006 };
            bool order3 = deliveryManager.PlaceOrder(3, order3Items);
            Console.WriteLine($"Order 3 (Curry): {(order3 ? "Placed" : "Failed")}");

            // Display restaurants by cuisine
            Console.WriteLine("\nRestaurants by Cuisine Type:");
            var grouped = deliveryManager.GroupRestaurantsByCuisine();
            foreach (var cuisine in grouped)
            {
                Console.WriteLine($"\n{cuisine.Key}:");
                foreach (var restaurant in cuisine.Value)
                {
                    Console.WriteLine($"  - {restaurant.Name} (Location: {restaurant.Location}, Delivery: ${restaurant.DeliveryCharge})");
                }
            }

            // Display pending orders
            Console.WriteLine("\nPending Orders:");
            var pendingOrders = deliveryManager.GetPendingOrders();
            foreach (var order in pendingOrders)
            {
                Console.WriteLine($"\nOrder ID: {order.OrderId} | Customer ID: {order.CustomerId} | Status: {order.Status}");
                Console.WriteLine($"  Items: {order.Items.Count} | Total: ${order.TotalAmount:F2} | Time: {order.OrderTime:yyyy-MM-dd HH:mm}");
            }
        }
    }
}
