using System;

namespace CarRentalAgency
{
    public class RentalCar
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; } // Sedan/SUV/Van
        public bool IsAvailable { get; set; }
        public double DailyRate { get; set; }
    }
}
