namespace _19CourierDeliveryTracking
{
    class Program
    {
        static void Main()
        {
            CourierManager manager = new CourierManager();

            // Add packages
            manager.AddPackage("Alice Johnson", "Bob Smith", "123 Main St, New York", 2.5, "Parcel", 15.99);
            manager.AddPackage("Charlie Brown", "Diana Prince", "456 Oak Ave, Los Angeles", 0.5, "Document", 5.99);
            manager.AddPackage("Eve Wilson", "Frank Castle", "789 Pine Rd, Chicago", 5.0, "Fragile", 25.99);
            manager.AddPackage("Grace Lee", "Henry Wilson", "321 Elm St, Houston", 1.2, "Parcel", 12.99);

            // Update status
            manager.UpdateStatus("TRK10000", "InTransit", "Sorting Facility A");
            manager.UpdateStatus("TRK10000", "InTransit", "Distribution Center");
            manager.UpdateStatus("TRK10000", "Delivered", "Destination");

            manager.UpdateStatus("TRK10001", "InTransit", "Local Courier");
            manager.UpdateStatus("TRK10002", "Dispatched", "Warehouse");

            // Group packages by type
            var packagesByType = manager.GroupPackagesByType();
            foreach (var group in packagesByType)
            {
                Console.WriteLine($"\nType: {group.Key}");
                foreach (var package in group.Value)
                {
                    Console.WriteLine($"  - {package.TrackingNumber}: {package.ReceiverName}");
                }
            }

            // Get packages by destination
            var nyPackages = manager.GetPackagesByDestination("New York");
            foreach (var package in nyPackages)
            {
                Console.WriteLine($"{package.TrackingNumber}: {package.ReceiverName}");
            }

            // Get delayed packages
            var delayedPackages = manager.GetDelayedPackages();
            if (delayedPackages.Count > 0)
            {
                foreach (var package in delayedPackages)
                {
                    Console.WriteLine($"{package.TrackingNumber}: {package.ReceiverName}");
                }
            }
            else
            {
                Console.WriteLine("No delayed packages.");
            }
        }
    }
}
