using System.Text.RegularExpressions;
public class PasswordGenerator
{
    public static bool IsValidUsername(string str)
    {
        if(!Regex.IsMatch(str, "^[A-Z]{4}@(10[1-9]|11[0-5])$"))
        {
            return false;
        }
        return true;
    }
    public static string GeneratePassword(string str)
    {
        int sum = 0;
        for(int i = 0; i < 4; i++)
        {
            sum += char.ToLower(str[i]);
        }
        string lastTwoDigits = str.Substring(6, 2);
        return "TECH_" + sum + lastTwoDigits;
    }

    public static void Main()
    {
        System.Console.WriteLine("Enter the username");
        string str = Console.ReadLine()!;

        if (!IsValidUsername(str))
        {
            System.Console.WriteLine(str + "  is an invalid username");
            return;
        }
        else
        {
            string password = GeneratePassword(str);
            Console.WriteLine("Password: " + password);
        }
    }
}