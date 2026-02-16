using System;
using Microsoft.Data.SqlClient;

namespace ADO
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=REDDY\\SQLEXPRESS;Database=CustomerOrder;Trusted_Connection=True;TrustServerCertificate=True;";

            #region DISPLAY ALL CUSTOMERS
            Console.WriteLine("----- All Customers -----");

            string selectSql = "SELECT CustomerId, FullName, City FROM dbo.Customers";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(selectSql, con))
            {
                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        $"{reader["CustomerId"]} | " +
                        $"{reader["FullName"]} | " +
                        $"{reader["City"]}"
                    );
                }
            }
            #endregion


            #region FILTER BY CITY
            Console.WriteLine("\n----- Filter By City -----");
            Console.Write("Enter City: ");
            string city = Console.ReadLine() ?? "";

            string filterSql = @"SELECT CustomerId, FullName, City
                                 FROM dbo.Customers
                                 WHERE City = @city";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(filterSql, con))
            {
                cmd.Parameters.AddWithValue("@city", city);

                con.Open();
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["CustomerId"]} | {reader["FullName"]} | {reader["City"]}");
                }
                con.Close();
            }
            #endregion


             Console.WriteLine("Enter operation (insert, update, delete): ");
        string op = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (op == "insert")
        {
            Console.Write("CustomerId: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Full Name: ");
            string fullName = Console.ReadLine() ?? "";
            Console.Write("City: ");
            string cityInsert = Console.ReadLine() ?? "";
            Console.Write("Segment: ");
            string segment = Console.ReadLine() ?? "";
            Console.Write("IsActive (true/false): ");
            bool isActive = bool.Parse(Console.ReadLine() ?? "true");

            string insertSql = "INSERT INTO dbo.Customers (CustomerId, FullName, City, Segment, IsActive, CreatedOn) VALUES (@id, @fullName, @city, @segment, @isActive, @createdOn)";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmdInsert = new SqlCommand(insertSql, con))
            {
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.Parameters.AddWithValue("@fullName", fullName);
                cmdInsert.Parameters.AddWithValue("@city", cityInsert);
                cmdInsert.Parameters.AddWithValue("@segment", segment);
                cmdInsert.Parameters.AddWithValue("@isActive", isActive);
                cmdInsert.Parameters.AddWithValue("@createdOn", DateTime.Now);
                con.Open();
                int rows = cmdInsert.ExecuteNonQuery();
                Console.WriteLine($"Inserted {rows} row(s).");
            }
        }
        else if (op == "update")
        {
            Console.Write("CustomerId to update: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("New Full Name: ");
            string newName = Console.ReadLine() ?? "";
            Console.Write("New City: ");
            string newCity = Console.ReadLine() ?? "";
            Console.Write("New Segment: ");
            string newSegment = Console.ReadLine() ?? "";
            Console.Write("IsActive (true/false): ");
            bool isActive = bool.Parse(Console.ReadLine() ?? "true");

            string updateSql = "UPDATE dbo.Customers SET FullName = @newName, City = @newCity, Segment = @segment, IsActive = @isActive WHERE CustomerId = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmdUpdate = new SqlCommand(updateSql, con))
            {
                cmdUpdate.Parameters.AddWithValue("@id", id);
                cmdUpdate.Parameters.AddWithValue("@newName", newName);
                cmdUpdate.Parameters.AddWithValue("@newCity", newCity);
                cmdUpdate.Parameters.AddWithValue("@segment", newSegment);
                cmdUpdate.Parameters.AddWithValue("@isActive", isActive);
                con.Open();
                int rows = cmdUpdate.ExecuteNonQuery();
                Console.WriteLine($"Updated {rows} row(s).");
            }
        }
        else if (op == "delete")
        {
            Console.Write("CustomerId to delete: ");
            string id = Console.ReadLine() ?? "";

            string deleteSql = "DELETE FROM dbo.Customers WHERE CustomerId = @id";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmdDelete = new SqlCommand(deleteSql, con))
            {
                cmdDelete.Parameters.AddWithValue("@id", id);
                con.Open();
                int rows = cmdDelete.ExecuteNonQuery();
                Console.WriteLine($"Deleted {rows} row(s).");
            }
        }
        else
        {
            Console.WriteLine("Unknown operation.");
        }
    }

    private static void NewMethod(SqlConnection con, out SqlCommand cmd, out SqlDataReader reader)
    {
        #region Query Command
        string sql = "SELECT CustomerId, FullName, City FROM dbo.Customers";
        cmd = new SqlCommand(sql, con);
        con.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["CustomerId"]} | " +
                $"{reader["FullName"]} | " +
                $"{reader["City"]}"
            );
        }
        con.Close();
        #endregion
    }
    }
}
