namespace _20RealEstatePropertyManagement
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string ClientType { get; set; } // Buyer/Renter
        public double Budget { get; set; }
        public List<string> Requirements { get; set; }

        public Client()
        {
            Requirements = new List<string>();
        }
    }
}
