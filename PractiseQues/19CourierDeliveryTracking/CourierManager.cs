namespace _19CourierDeliveryTracking
{
    public class CourierManager
    {
        private List<Package> packages;
        private List<DeliveryStatus> deliveryStatuses;
        private int trackingCounter;

        public CourierManager()
        {
            packages = new List<Package>();
            deliveryStatuses = new List<DeliveryStatus>();
            trackingCounter = 10000;
        }

        public void AddPackage(string sender, string receiver, string address, double weight, string type, double cost)
        {
            string trackingNumber = $"TRK{trackingCounter++}";
            packages.Add(new Package
            {
                TrackingNumber = trackingNumber,
                SenderName = sender,
                ReceiverName = receiver,
                DestinationAddress = address,
                Weight = weight,
                PackageType = type,
                ShippingCost = cost
            });

            deliveryStatuses.Add(new DeliveryStatus
            {
                TrackingNumber = trackingNumber,
                CurrentStatus = "Dispatched",
                EstimatedDelivery = DateTime.Now.AddDays(3),
                ActualDelivery = DateTime.MinValue
            });

            Console.WriteLine($"Package registered: {trackingNumber}");
        }

        public bool UpdateStatus(string trackingNumber, string status, string checkpoint)
        {
            var delivery = deliveryStatuses.FirstOrDefault(d => d.TrackingNumber == trackingNumber);
            if (delivery == null)
            {
                Console.WriteLine($"Tracking number {trackingNumber} not found!");
                return false;
            }

            delivery.CurrentStatus = status;
            delivery.Checkpoints.Add($"{checkpoint} ({DateTime.Now:yyyy-MM-dd HH:mm})");

            if (status.ToLower() == "delivered")
            {
                delivery.ActualDelivery = DateTime.Now;
            }

            Console.WriteLine($"Status updated for {trackingNumber}: {status} at {checkpoint}");
            return true;
        }

        public Dictionary<string, List<Package>> GroupPackagesByType()
        {
            return packages.GroupBy(p => p.PackageType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Package> GetPackagesByDestination(string city)
        {
            return packages.Where(p => p.DestinationAddress.Contains(city, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Package> GetDelayedPackages()
        {
            var delayedTrackingNumbers = deliveryStatuses
                .Where(d => d.CurrentStatus != "Delivered" && d.EstimatedDelivery < DateTime.Now)
                .Select(d => d.TrackingNumber)
                .ToList();

            return packages.Where(p => delayedTrackingNumbers.Contains(p.TrackingNumber)).ToList();
        }
    }
}
