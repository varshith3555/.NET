using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalAgency
{
    public class RentalManager
    {
        private List<RentalCar> cars = new List<RentalCar>();
        private List<Rental> rentals = new List<Rental>();
        private int rentalId = 5001;

        public void AddCar(string license, string make, string model, string type, double rate)
        {
            if (string.IsNullOrWhiteSpace(license))
                throw new ArgumentException("License plate cannot be empty.");

            cars.Add(new RentalCar
            {
                LicensePlate = license,
                Make = make,
                Model = model,
                CarType = type,
                IsAvailable = true,
                DailyRate = rate
            });
        }

        public bool RentCar(string license, string customer, DateTime start, int days)
        {
            var car = cars.FirstOrDefault(c => c.LicensePlate == license);
            if (car == null)
                throw new Exception("Car not found.");

            if (!car.IsAvailable)
                return false;

            DateTime endDate = start.AddDays(days);
            double totalCost = car.DailyRate * days;

            car.IsAvailable = false;
            rentals.Add(new Rental
            {
                RentalId = rentalId++,
                LicensePlate = license,
                CustomerName = customer,
                StartDate = start,
                EndDate = endDate,
                TotalCost = totalCost
            });

            return true;
        }

        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            var grouped = new Dictionary<string, List<RentalCar>>();
            foreach (var car in cars.Where(c => c.IsAvailable))
            {
                if (!grouped.ContainsKey(car.CarType))
                    grouped[car.CarType] = new List<RentalCar>();
                grouped[car.CarType].Add(car);
            }
            return grouped;
        }

        public List<Rental> GetActiveRentals()
        {
            return rentals.Where(r => r.EndDate >= DateTime.Now).ToList();
        }

        public double CalculateTotalRentalRevenue()
        {
            return rentals.Sum(r => r.TotalCost);
        }
    }
}
