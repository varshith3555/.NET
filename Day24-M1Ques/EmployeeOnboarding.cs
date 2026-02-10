namespace M1Ques
{
    class Employee
    {
        public int Id;
        public string Name;
        public string Email;
        public double Salary;

        public Employee(int id, string name, string email, double salary)
        {
            Id = id;
            Name = name;
            if(salary <= 0)
            {
                Salary = 30000;
            }
            else
            {
                Salary = salary;
            }
            if (!email.Contains('@'))
            {
                Email = "unknown@company.com";
            }
            else
            {
                Email = email;
            }
        }
    }
    class EmployeeMain
    {
        public static void Main()
        {
            Employee e1 = new  Employee(1, "Varshith", "varshith123@gmail.com", 333);
            Employee e2 = new  Employee(2, "Nani", "nani@gmail.com", 7777777);
            Employee e3 = new  Employee(3, "Mani", "mani@gmail.com", -123);
            System.Console.WriteLine(e1.Id + e1.Name + e1.Email + e1.Salary);
            System.Console.WriteLine(e2.Id + e2.Name + e2.Email + e2.Salary);
            System.Console.WriteLine(e3.Id + e3.Name + e3.Email + e3.Salary);
        }
    }
}