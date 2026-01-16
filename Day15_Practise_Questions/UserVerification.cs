namespace Day15_Practise_Questons
{
    class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string message) : base(message)
        {
        }
    }
    class User1
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
    class UserVerification
    {
        public static User1 ValidatePhoneNumber(string name, string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                User1 user = new User1();
                user.Name = name;
                user.PhoneNumber = phoneNumber;
                return user;
            }
            else
            {
                throw new InvalidPhoneNumberException("Invalid phone number");
            }
        }
        static void Main()
        {
            try
            {
                string name = Console.ReadLine();
                string phoneNumber = Console.ReadLine();

                User1 res = ValidatePhoneNumber(name, phoneNumber);
                Console.WriteLine("User verified successfully");
            }catch (InvalidPhoneNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }   
}