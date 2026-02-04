using System;

class OrderProcessor
{
    static void Main()
    {
        int[] orders = { 101, -1, 103 };

        foreach(int order in orders)
        {
            try
            {
                if(order <= 0)
                {
                    throw new Exception("Invalid order ID: " + order);
                }
                Console.WriteLine("Order processed successfully: " + order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing order: " + ex.Message);
            }
        }
    }
}
