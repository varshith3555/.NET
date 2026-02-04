using System.Text.RegularExpressions;

public class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message)
    {
        
    }
}
public class GadgetValidatorUtil
{
    public bool validateGadgetID(string gadgetID)
    {
        if(Regex.IsMatch(gadgetID, "^[A-z][0-9]{3}$"))
        {
            return true;
        }
        else
        {
            throw new InvalidGadgetException("Invalid gadget id");
        }
    }
    public bool validateWarrantyPeriod(int period)
    {
        if(period >= 6 && period <= 36)
        {
            return true;
        }
        else
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }
    }    
}

public class UserInterface2
{
    public static void Main()
    {
        GadgetValidatorUtil g = new GadgetValidatorUtil();
        System.Console.WriteLine("Enter the number of gadget entries");
        int n = int.Parse(Console.ReadLine()!);

        for(int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter gadget {i} details");
            string? input = Console.ReadLine();
            try
            {
                string[] parts = input!.Split(":");
                g.validateGadgetID(parts[0]);
                g.validateWarrantyPeriod(int.Parse(parts[2]));
                System.Console.WriteLine("Warranty accepted, stock updated");
            }
            catch(InvalidGadgetException e)
            {
                System.Console.WriteLine(e.Message);
            }       
        }
    }
}	