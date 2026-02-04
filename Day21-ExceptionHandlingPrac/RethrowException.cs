using System;

class ExceptionRethrow
{
    static void Main()
    {
        try
        {
            ProcessData();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception second handled in Main: " + ex.Message);
        }
    }
    static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception first logged in ProcessData: " + ex.Message);
            throw; // rethrow
        }
    }
}
