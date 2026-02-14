namespace LogisticsPro
{
    class Program
    {
        static void Main()
        {
            ShipmentDetails sd = new ShipmentDetails();
            System.Console.WriteLine("Enter the Shipment code");
            sd.ShipmentCode = Console.ReadLine()!;

            if (sd.ValidateShipmentCode())
            {
                System.Console.WriteLine("Enter the transmode mode");
                sd.TransportMode = Console.ReadLine()!;
                System.Console.WriteLine("Enter weight");
                sd.Weight = double.Parse(Console.ReadLine()!);
                System.Console.WriteLine("Enter storage days");
                sd.StorageDays = int.Parse(Console.ReadLine()!);
                
                double cost = sd.CalculateTotalCost();
                System.Console.WriteLine("The total shipping cost is" + cost);
            }else{
                System.Console.WriteLine("Invalid shipment code");
            }
        }
    }
}