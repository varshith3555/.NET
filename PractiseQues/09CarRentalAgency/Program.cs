using System;

namespace CarRentalAgency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Car Rental Agency System");
            var rentalManager = new RentalManager();

            // Add cars
            rentalManager.AddCar("ABC123", "Toyota", "Camry", "Sedan", 50.00);
            rentalManager.AddCar("DEF456", "Honda", "Accord", "Sedan", 48.00);
            rentalManager.AddCar("GHI789", "Ford", "Explorer", "SUV", 75.00);
            rentalManager.AddCar("JKL012", "Chevrolet", "Tahoe", "SUV", 80.00);
            rentalManager.AddCar("MNO345", "Mercedes", "Sprinter", "Van", 100.00);

            // Rent cars
            Console.WriteLine("Renting Cars:");
            bool rent1 = rentalManager.RentCar("ABC123", "John Smith", DateTime.Now, 5);
            Console.WriteLine($"Rent ABC123 (Toyota Camry) for 5 days: {(rent1 ? "Success" : "Failed")}");

            bool rent2 = rentalManager.RentCar("GHI789", "Jane Doe", DateTime.Now, 7);
            Console.WriteLine($"Rent GHI789 (Ford Explorer) for 7 days: {(rent2 ? "Success" : "Failed")}");

            bool rent3 = rentalManager.RentCar("MNO345", "Bob Wilson", DateTime.Now, 3);
            Console.WriteLine($"Rent MNO345 (Mercedes Sprinter) for 3 days: {(rent3 ? "Success" : "Failed")}");

            // Display total revenue
            Console.WriteLine($"\nTotal Rental Revenue: ${rentalManager.CalculateTotalRentalRevenue():F2}");

            // Display available cars by type
            Console.WriteLine("\nAvailable Cars by Type:");
            var grouped = rentalManager.GroupCarsByType();
            foreach (var type in grouped)
            {
                Console.WriteLine($"\n{type.Key}:");
                foreach (var car in type.Value)
                {
                    Console.WriteLine($"  - {car.Make} {car.Model} ({car.LicensePlate}) - ${car.DailyRate}/day");
                }
            }

            // Display active rentals
            Console.WriteLine("\nActive Rentals:");
            var activeRentals = rentalManager.GetActiveRentals();
            foreach (var rental in activeRentals)
            {
                Console.WriteLine($"Rental ID: {rental.RentalId} | Customer: {rental.CustomerName}");
                Console.WriteLine($"  Car: {rental.LicensePlate} | Period: {rental.StartDate:yyyy-MM-dd} to {rental.EndDate:yyyy-MM-dd}");
                Console.WriteLine($"  Total Cost: ${rental.TotalCost:F2}");
            }
        }
    }
}
