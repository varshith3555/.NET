using System;

class DatabaseConnection
{
    static void Main()
    {
        bool isConnected = false;

        try
        {
            isConnected = true;     // Open connection
            Console.WriteLine("Database connection opened.");

            throw new Exception("Database operation failed.");   // Simulate operation failure
        }
        catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            // Ensure connection is closed properly
            if(isConnected)
            {
                isConnected = false;
                Console.WriteLine("Database connection closed.");
            }
        }
    }
}
