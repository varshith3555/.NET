using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program1
{
    static void Main()
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=CustomerOrder;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SeleCT CustomerId, FullName, City FROM dbo.Customers";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(connectionString))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }
        ds.WriteXml("TestData");

        Console.WriteLine(ds.Tables.Count);
        foreach(DataColumn item in ds.Tables[0].Columns){
            System.Console.WriteLine(item.ColumnName+"\t");
        }
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
    }
}