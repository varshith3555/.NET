using System.Reflection;

public class Employee2
{
    // ===== Fields =====
    public int Id;
    private double salary;
    protected string department = "IT";
    internal string company = "ABC Corp";

    // ===== Properties =====
    public string? Name { get; set; }
    private int Age { get; set; }
    protected string? Address { get; set; }
    internal string? Email { get; set; }

    // ===== Constructors =====
    public Employee2()
    {
        Id = 0;
        salary = 0;
    }

    public Employee2(int id, string name)
    {
        Id = id;
        Name = name;
        salary = 25000;
    }

    // ===== Public Methods =====
    public void DisplayPublic()
    {
        Console.WriteLine("Public Method Called");
    }

    public string GetEmployeeInfo()
    {
        return $"{Id} - {Name}";
    }

    // ===== Private Method =====
    private void CalculateSalary()
    {
        salary += 1000;
    }

    // ===== Protected Method =====
    protected void ProtectedMethod()
    {
        Console.WriteLine("Protected Method");
    }

    // ===== Internal Method =====
    internal void InternalMethod()
    {
        Console.WriteLine("Internal Method");
    }

    // ===== Static Method =====
    public static void StaticMethod()
    {
        Console.WriteLine("Static Method");
    }

    // ===== Overloaded Methods =====
    public void PrintData(string msg)
    {
        Console.WriteLine(msg);
    }

    public void PrintData(string msg, int number)
    {
        Console.WriteLine($"{msg} {number}");
    }

    // ===== Virtual Method (for advanced reflection later) =====
    public virtual void VirtualMethod()
    {
        Console.WriteLine("Employee Virtual Method");
    }
}

class Program8
{
    static void Main()
    {
        // Type t = typeof(Employee2);
        // var methods = t.GetMethods();
        // foreach(var i in methods)
        // {
        //     System.Console.WriteLine(i.ReturnType.Name + " - "+ i.Name);
        // }

        Employee2 emp = new Employee2(1, "Capp");
        Type c2 = emp.GetType();
        System.Console.WriteLine(c2.FullName);

        // Invoke public method
        c2.GetMethod("DisplayPublic")?.Invoke(emp, null);
        // Invoke method with return value
        var result = c2.GetMethod("GetEmployeeInfo")?.Invoke(emp, null);
        Console.WriteLine("Returned: " + result);
        // Invoke overloaded method (1 param)
        // c2.GetMethod("PrintData", new Type[] { typeof(string) })?.Invoke(emp, new object[] {"Varshith" });
        // c2.GetMethod("PrintData", new Type[] { typeof(string), typeof(int) })?.Invoke(emp, new object[] { "Varshith", 7 }); // Invoke overloaded method (2 param)

        c2.GetMethod("CalculateSalary", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(emp, null); // Invoke private method
        c2.GetMethod("ProtectedMethod", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(emp, null); // Invoke protected method
        c2.GetMethod("StaticMethod")?.Invoke(null, null);
        // var methods1 = c2.GetMethods(
        //     BindingFlags.Instance | BindingFlags.Static |
        //     BindingFlags.Public | BindingFlags.DeclaredOnly
        // );
        // foreach(var i in methods1)
        // {
        //     System.Console.WriteLine(i.ReturnType.Name + " - "+ i.Name);
        // }

        var properties = c2.GetProperties(
            BindingFlags.Instance |
            BindingFlags.Public |
            BindingFlags.NonPublic |
            BindingFlags.DeclaredOnly
        );

        foreach (var p in properties)
        {
            Console.WriteLine(p.PropertyType.Name + " - " + p.Name);
        }


    }
}