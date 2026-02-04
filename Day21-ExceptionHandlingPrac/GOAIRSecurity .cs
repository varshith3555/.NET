using System.Text.RegularExpressions;

public class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message)
    {
        
    }
}
class EntryUtility
{
    public bool validateEmployeeld(string employeeId)
    {
        if(employeeId.Length != 10)
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        if(!Regex.IsMatch(employeeId, "^GOAIR/[0-9]{4}$"))
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        return true;
    }
    public bool validateDuration(int duration)
    {
        if(duration < 1 || duration > 5)
        {
            throw new InvalidEntryException("Invalid entry details");
        }
        return true;
    }
}
class UserInterface1
{
    public static void Main()
    {
        EntryUtility eu = new EntryUtility();
        System.Console.WriteLine("Enter the number of entries");
        int n = int.Parse(Console.ReadLine()!);

        for(int i = 1; i <= n; i++)
        {
            System.Console.WriteLine($"Enter entry {i} details");
            string input = Console.ReadLine()!;
            try{
                string[] parts = input.Split(":");
                eu.validateEmployeeld(parts[0]);
                eu.validateDuration(int.Parse(parts[2]));
                System.Console.WriteLine("Valid entry details");
            }
            catch(InvalidEntryException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}