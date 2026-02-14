class PasswordMasking
{
    static void Main()
    {
        string pass = Console.ReadLine()!;
        string res = MaskPassword(pass);
        System.Console.WriteLine(res);
    }
    public static string MaskPassword(string password)
    {
        if(password.Length < 3)
        {
            return password;
        }
        return password[0] + new string('*', password.Length - 2)+  password[password.Length - 1];
    }
}