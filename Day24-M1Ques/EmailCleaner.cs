using Microsoft.Win32.SafeHandles;

class EmailCleaner
{
    static void Main()
    {
        string email = Console.ReadLine()!;
        MailChecker(email);
    }
    public static void MailChecker(String email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            System.Console.WriteLine("Invalid Email");
            return;
        }
        email = email.Trim();
        email = email.ToLower().Replace(" ", "");
        if (email.Contains("@gmail.com"))
        {
            email = email.Replace("@gmail.com", "@company.com");
        }
        System.Console.WriteLine(email);
    }
}