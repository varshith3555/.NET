namespace Day15_Practise_Questons
{
    class PasswordMismatchException : Exception
    {
        public PasswordMismatchException(string message) : base(message)
        {
        }
    }

    class User
    {
        public string? Name{ get; set; }
        public string? Password { get; set; }
        public string? ConfirmationPassword { get; set; }
    }

    class PasswordMain
    {
        public User ValidatePassword(string name, string password, string confirmationPassword)
        {
            if (!password.Equals(confirmationPassword))
            {
                throw new PasswordMismatchException(
                    "Password entered does not match"
                );
            }
            User user = new User();
            user.Name = name;
            user.Password = password;
            user.ConfirmationPassword = confirmationPassword;
            return user;
        }

        static void Main(string[] args)
        {
            PasswordMain program = new PasswordMain();

            try
            {
                // Sample input (change values to test)
                User user = program.ValidatePassword(
                    "John",
                    "Password123",
                    "Password123"
                );

                if (user != null)
                {
                    Console.WriteLine("Registered Successfully");
                }
            }
            catch (PasswordMismatchException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}