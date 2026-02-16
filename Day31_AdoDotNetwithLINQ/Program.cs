using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
class Program
{
    static void Main()
    {
        string connectionString = "Server=REDDY\\SQLEXPRESS;Database=CustomerOrder;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT CustomerId, FullName, City, Segment, IsActive, CreatedOn FROM dbo.Customers";

        DataTable customers = new DataTable();
        using (var con = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(sql, con))
        using (var adapter = new SqlDataAdapter(cmd))
        {
            adapter.Fill(customers);
        }
        Console.WriteLine($"Total Customers: {customers.Rows.Count}");

        // Example A: City == "Chennai" (filter + projection)
        string city = "Chennai";
        var chennaiCustomers = customers.AsEnumerable().Where(r => r.Field<string>("City") == city).Select(r => r.Field<string>("FullName")).ToList();
        Console.WriteLine($"\nCustomers in {city}:");
        chennaiCustomers.ForEach(Console.WriteLine);

        // Example B: Active customers (filter + projection)
        var activeCustomers = customers.AsEnumerable().Where(r => r.Field<bool>("IsActive") == true)
            .Select(r => new
            {
                Id = r.Field<int>("CustomerId"),
                Name = r.Field<string>("FullName"),
                City = r.Field<string>("City")
            }).ToList();
        Console.WriteLine("\nActive Customers:");
        foreach (var c in activeCustomers)
        {
            Console.WriteLine($"{c.Id} | {c.Name} | {c.City}");
        }

        // Example C: Group by City (grouping)
        var cityGroups = customers.AsEnumerable()
            .GroupBy(r => r.Field<string>("City"))
            .Select(g => new
            {
                City = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(g => g.Count).ToList();
        Console.WriteLine("\nCustomer Count By City:");
        foreach (var g in cityGroups)
        {
            Console.WriteLine($"{g.City} : {g.Count}");
        }
    }
}