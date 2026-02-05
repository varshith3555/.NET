namespace _17InventoryStockManagement
{
    class Program
    {
        static void Main()
        {
            InventoryManager manager = new InventoryManager();

            // Add products
            manager.AddProduct("P001", "Laptop", "Electronics", "Dell Corp", 999.99, 50, 10);
            manager.AddProduct("P002", "Mouse", "Electronics", "Logitech", 29.99, 100, 20);
            manager.AddProduct("P003", "Desk Chair", "Furniture", "FurnitureCo", 199.99, 15, 5);
            manager.AddProduct("P004", "Monitor", "Electronics", "LG", 299.99, 8, 10);
            manager.AddProduct("P005", "Keyboard", "Electronics", "Corsair", 79.99, 30, 15);

            // Update stock - add stock
            manager.UpdateStock("P001", "In", 20, "Purchase");
            manager.UpdateStock("P003", "In", 10, "Purchase");

            // Update stock - remove stock
            manager.UpdateStock("P002", "Out", 15, "Sale");
            manager.UpdateStock("P004", "Out", 8, "Sale");

            // Group products by category
            var productsByCategory = manager.GroupProductsByCategory();
            foreach (var group in productsByCategory)
            {
                Console.WriteLine($"\nCategory: {group.Key}");
                foreach (var product in group.Value)
                {
                    Console.WriteLine($"  - {product.ProductName} (Stock: {product.CurrentStock})");
                }
            }

            // Get low stock products
            var lowStockProducts = manager.GetLowStockProducts();
            if (lowStockProducts.Count > 0)
            {
                foreach (var product in lowStockProducts)
                {
                    Console.WriteLine($"{product.ProductName}: {product.CurrentStock} units (Min: {product.MinimumStockLevel})");
                }
            }
            else
            {
                Console.WriteLine("All products have sufficient stock.");
            }

            // Get stock value by category
            var stockValueByCategory = manager.GetStockValueByCategory();
            foreach (var category in stockValueByCategory)
            {
                Console.WriteLine($"{category.Key}: ${category.Value}");
            }
        }
    }
}
