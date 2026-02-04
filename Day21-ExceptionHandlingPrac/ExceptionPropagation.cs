class Controller
{
    static void Main()
    {
        try
        {
            Service.Process();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Exception handled in Controller: "+ex.Message);
        }
    }
}
class Service
{
    public static void Process()
    {
        try
        {
            Repository.GetData();
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception logged in Service: " + e.Message);
            throw;
        }
    }
}
class Repository
{
    public static void GetData()
    {
        throw new Exception("Data access error in Repository");
    }
}