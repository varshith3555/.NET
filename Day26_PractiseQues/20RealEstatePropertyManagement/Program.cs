namespace _20RealEstatePropertyManagement
{
    class Program
    {
        static void Main()
        {
            RealEstateManager manager = new RealEstateManager();

            // Add properties
            manager.AddProperty("123 Main St, NYC", "Apartment", 2, 1200, 250000, "John Realty");
            manager.AddProperty("456 Oak Ave, LA", "House", 4, 2500, 450000, "LA Properties");
            manager.AddProperty("789 Palm Dr, Miami", "Villa", 5, 4000, 750000, "Luxury Homes");
            manager.AddProperty("321 Pine Rd, Chicago", "Apartment", 1, 800, 150000, "Urban Living");

            // Add clients
            manager.AddClient("Alice Johnson", "alice@email.com", "Buyer", 300000, new List<string> { "2+ bedrooms", "Modern kitchen" });
            manager.AddClient("Bob Smith", "bob@email.com", "Renter", 2000, new List<string> { "1 bedroom", "Close to metro" });
            manager.AddClient("Carol Davis", "carol@email.com", "Buyer", 800000, new List<string> { "Luxury", "Pool", "Garden" });

            // Schedule viewings
            manager.ScheduleViewing("PROP1", 1, DateTime.Now.AddDays(5));
            manager.ScheduleViewing("PROP2", 3, DateTime.Now.AddDays(7));
            manager.ScheduleViewing("PROP4", 2, DateTime.Now.AddDays(3));

            // Group properties by type
            var propertiesByType = manager.GroupPropertiesByType();
            foreach (var group in propertiesByType)
            {
                Console.WriteLine($"\nType: {group.Key}");
                foreach (var property in group.Value)
                {
                    Console.WriteLine($"  - {property.Address}: ${property.Price}");
                }
            }

            // Get properties in budget range
            var budgetProperties = manager.GetPropertiesInBudget(200000, 500000);
            foreach (var property in budgetProperties)
            {
                Console.WriteLine($"{property.Address}: ${property.Price}");
            }
        }
    }
}
