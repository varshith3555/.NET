using System.Data.Common;

public class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message)
    {

    }
}
public class EntryUtility
{
    public static bool validateEmployeeId(string EmpId)
    {
        if (EmpId.Length != 10)
            throw new InvalidEntryException("Invalid Employee ID");

        if (!EmpId.StartsWith("GOAIR/"))
            throw new InvalidEntryException("Invalid Employee ID");

        for (int i = 6; i < 10; i++)
        {
            if (!char.IsDigit(EmpId[i]))
                throw new InvalidEntryException("Invalid Employee ID");
        }

        return true;
    }

    public static bool validateDuration(int duration)
    {
        if (duration < 1 || duration > 5)
            throw new InvalidEntryException("Invalid Duration");
           return true;
    }
}

public class UserInterface
{
    public static void Main()
    {
        System.Console.WriteLine("Enter the number of entries");
        int no = int.Parse(Console.ReadLine());
        for (int i = 1; i <= no; i++)
        {
            Console.WriteLine($"Enter entry {i} details");
            string input = Console.ReadLine();

            try
            {
                string[] parts = input.Split(':');

                string employeeId = parts[0];
                int duration = int.Parse(parts[2]);

                EntryUtility.validateEmployeeId(employeeId);
                EntryUtility.validateDuration(duration);

                Console.WriteLine("Valid entry details");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry details");
            }
        }
    }
}