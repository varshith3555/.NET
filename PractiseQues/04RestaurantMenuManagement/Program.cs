using System;
using System.Collections.Generic;

namespace RestaurantMenuManagement;

class Program
{
    static void Main()
    {
        MenuManager menuManager = new MenuManager();

        // 1. Add menu items (Appetizer / Main Course / Dessert)
        menuManager.AddMenuItem("Spring Rolls", "Appetizer", 120, true);
        menuManager.AddMenuItem("Chicken Wings", "Appetizer", 180, false);
        menuManager.AddMenuItem("Paneer Butter Masala", "Main Course", 250, true);
        menuManager.AddMenuItem("Chicken Biryani", "Main Course", 300, false);
        menuManager.AddMenuItem("Gulab Jamun", "Dessert", 90, true);

        // 2. Display menu grouped by category
        Console.WriteLine("Menu Grouped By Category:");
        Dictionary<string, List<MenuItem>> groupedMenu =
            menuManager.GroupItemsByCategory();

        foreach (var category in groupedMenu)
        {
            Console.WriteLine("\nCategory: " + category.Key);
            foreach (var item in category.Value)
            {
                Console.WriteLine(
                    item.ItemName + " | " +
                    item.Price + " | Veg: " +
                    item.IsVegetarian
                );
            }
        }

        // 3. Display vegetarian items
        Console.WriteLine("\nVegetarian Menu Items:");
        List<MenuItem> vegItems =
            menuManager.GetVegetarianItems();

        foreach (var item in vegItems)
        {
            Console.WriteLine(item.ItemName + " - " + item.Price);
        }

        // 4. Calculate average price per category
        Console.WriteLine("\nAverage Price Per Category:");
        Console.WriteLine("Appetizer: " +
            menuManager.CalculateAveragePriceByCategory("Appetizer"));
        Console.WriteLine("Main Course: " +
            menuManager.CalculateAveragePriceByCategory("Main Course"));
        Console.WriteLine("Dessert: " +
            menuManager.CalculateAveragePriceByCategory("Dessert"));
    }
}
