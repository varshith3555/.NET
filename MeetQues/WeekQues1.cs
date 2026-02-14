using System;
using System.Collections.Generic;

class Bike
{
    public string Model{get; set;}
    public string Brand{get; set;}
    public int PricePerDay{get; set;}
}
    
class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        int key = Program.bikeDetails.Count + 1;
        Bike bike = new Bike
        {
            Model = model,
            Brand = brand,
            PricePerDay = pricePerDay
        };
        Program.bikeDetails.Add(key, bike);
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> result =
            new SortedDictionary<string, List<Bike>>();

        foreach(var item in Program.bikeDetails)
        {
            Bike bike = item.Value;
            if(!result.ContainsKey(bike.Brand))
                result[bike.Brand] = new List<Bike>();
            result[bike.Brand].Add(bike);
        }
        return result;
    }
}

class Program
{
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();

    static void Main()
    {
        BikeUtility utility = new BikeUtility();
        while(true)
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.WriteLine("Enter your choice");

            int choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Console.WriteLine("Enter the model");
                string model = Console.ReadLine();

                Console.WriteLine("Enter the brand");
                string brand = Console.ReadLine();

                Console.WriteLine("Enter the price per day");
                int price = int.Parse(Console.ReadLine());

                utility.AddBikeDetails(model, brand, price);

                Console.WriteLine("Bike details added successfully");
                Console.WriteLine();
            }
            else if(choice == 2)
            {
                var grouped = utility.GroupBikesByBrand();

                foreach(var item in grouped)
                {
                    Console.WriteLine(item.Key);
                    foreach(var bike in item.Value)
                        Console.WriteLine(bike.Model);

                    Console.WriteLine();
                }
            }
            else if(choice == 3)
            {
                break;
            }
        }
    }
}
