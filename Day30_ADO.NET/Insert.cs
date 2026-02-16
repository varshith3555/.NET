using System;
using Microsoft.Data.SqlClient;

class Program2
{
    static void Main()
    {
        string connectionString = 
        "Server=localhost\\SQLEXPRESS;Database=CustomerOrder;Trusted_Connection=True;TrustServerCertificate=True;";

        string sql = "UPDATE dbo.Customers SET City = @city WHERE CustomerId = @id";

        using (var con = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@city", "Mumbai");
            cmd.Parameters.AddWithValue("@id", 105);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Update successful");
            else
                Console.WriteLine("No record found");
        }
    }
}
