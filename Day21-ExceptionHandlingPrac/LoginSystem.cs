class LoginSystem
{
    static void Main()
    {
        int attempts = 0;
        try
        {
            while(attempts < 3)
            {
                System.Console.WriteLine("Enter password: ");
                string password = Console.ReadLine()!;
                attempts++;
            }
            throw new LimitExceededException("Login attempts exceeded");
        }catch(LimitExceededException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
}
class LimitExceededException : Exception
{
    public LimitExceededException(string message) : base(message)
    {
        
    }
}