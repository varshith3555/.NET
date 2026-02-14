namespace _20RealEstatePropertyManagement
{
    public class RealEstateManager
    {
        private List<Property> properties;
        private List<Client> clients;
        private List<Viewing> viewings;
        private int propertyIdCounter;
        private int clientIdCounter;
        private int viewingIdCounter;

        public RealEstateManager()
        {
            properties = new List<Property>();
            clients = new List<Client>();
            viewings = new List<Viewing>();
            propertyIdCounter = 1;
            clientIdCounter = 1;
            viewingIdCounter = 1;
        }

        public void AddProperty(string address, string type, int bedrooms, double area, double price, string owner)
        {
            properties.Add(new Property
            {
                PropertyId = $"PROP{propertyIdCounter++}",
                Address = address,
                PropertyType = type,
                Bedrooms = bedrooms,
                AreaSqFt = area,
                Price = price,
                Status = "Available",
                Owner = owner
            });
            Console.WriteLine($"Property added: {address}");
        }

        public void AddClient(string name, string contact, string type, double budget, List<string> requirements)
        {
            clients.Add(new Client
            {
                ClientId = clientIdCounter++,
                Name = name,
                Contact = contact,
                ClientType = type,
                Budget = budget,
                Requirements = new List<string>(requirements)
            });
            Console.WriteLine($"Client '{name}' registered successfully!");
        }

        public bool ScheduleViewing(string propertyId, int clientId, DateTime date)
        {
            var property = properties.FirstOrDefault(p => p.PropertyId == propertyId);
            if (property == null)
            {
                Console.WriteLine($"Property {propertyId} not found!");
                return false;
            }

            var client = clients.FirstOrDefault(c => c.ClientId == clientId);
            if (client == null)
            {
                Console.WriteLine($"Client {clientId} not found!");
                return false;
            }

            viewings.Add(new Viewing
            {
                ViewingId = viewingIdCounter++,
                PropertyId = propertyId,
                ClientId = clientId,
                ViewingDate = date,
                Feedback = ""
            });

            Console.WriteLine($"Viewing scheduled for {client.Name} at {property.Address} on {date:yyyy-MM-dd HH:mm}");
            return true;
        }

        public Dictionary<string, List<Property>> GroupPropertiesByType()
        {
            return properties.GroupBy(p => p.PropertyType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<Property> GetPropertiesInBudget(double minPrice, double maxPrice)
        {
            return properties.Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.Status == "Available")
                .OrderBy(p => p.Price)
                .ToList();
        }
    }
}
