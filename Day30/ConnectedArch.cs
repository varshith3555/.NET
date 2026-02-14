using System;
using Microsoft.Data.SqlClient;

namespace ADO
{
    class Program
    {
        static void Main()
        {
            string connectionString =
            "Server=REDDY\\SQLEXPRESS;Database=CustomerOrder;Trusted_Connection=True;TrustServerCertificate=True;";

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
                    Console.WriteLine(
                        $"{reader["CustomerId"]} | " +
                        $"{reader["FullName"]} | " +
                        $"{reader["City"]}"
                    );
                }
            }
            #endregion


            #region INSERT
            Console.WriteLine("\n----- Insert New Customer -----");

            Console.Write("Enter CustomerId: ");
            int newId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter FullName: ");
            string newName = Console.ReadLine() ?? "";

            Console.Write("Enter City: ");
            string newCity = Console.ReadLine() ?? "";

            string insertSql = @"INSERT INTO dbo.Customers
                                 (CustomerId, FullName, City, CreatedOn)
                                 VALUES (@id, @name, @city, @createdOn)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(insertSql, con))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = newId;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 100).Value = newName;
                cmd.Parameters.Add("@city", System.Data.SqlDbType.NVarChar, 100).Value = newCity;
                cmd.Parameters.Add("@createdOn", System.Data.SqlDbType.DateTime).Value = DateTime.Now;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Insert Successful" : "Insert Failed");
            }
            #endregion


            #region UPDATE
            Console.WriteLine("\n----- Update Customer City -----");

            Console.Write("Enter CustomerId to Update: ");
            int updateId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter New City: ");
            string updateCity = Console.ReadLine() ?? "";

            string updateSql = @"UPDATE dbo.Customers
                                 SET City = @city
                                 WHERE CustomerId = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(updateSql, con))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = updateId;
                cmd.Parameters.Add("@city", System.Data.SqlDbType.NVarChar, 100).Value = updateCity;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Update Successful" : "No Record Found");
            }
            #endregion


            #region DELETE
            Console.WriteLine("\n----- Delete Customer -----");

            Console.Write("Enter CustomerId to Delete: ");
            int deleteId = int.Parse(Console.ReadLine() ?? "0");

            string deleteSql = @"DELETE FROM dbo.Customers
                                 WHERE CustomerId = @id";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteSql, con))
            {
                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = deleteId;

                con.Open();
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Delete Successful" : "No Record Found");
            }
            #endregion

            Console.WriteLine("\nProgram Finished.");
        }
    }
}
