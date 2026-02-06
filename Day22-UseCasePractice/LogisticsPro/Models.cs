using System.Text.RegularExpressions;

namespace LogisticsPro
{
    class Shipment
    {
        public string ShipmentCode{get; set;}
        public string TransportMode{get; set;}
        public double Weight{get; set;}
        public int StorageDays{get; set;}
    }
    class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            if(Regex.IsMatch(ShipmentCode, @"^GC#[0-9]{4}$"))
            {
                return true;
            }
            return false;
        }
        public double CalculateTotalCost()
        {
            double ratePerKg = 0;

            switch(TransportMode){
                case "Sea":
                    ratePerKg =  15.00; 
                    break;
                case "Air":
                    ratePerKg =  50.00;
                    break;
                case "Land":
                    ratePerKg = 25.00;
                    break;
            }
            return ratePerKg;
        }
    }
}