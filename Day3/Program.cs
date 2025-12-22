using System;

#region Base Class
// Base class representing a generic person
public class Person
{
    // Unique identifier
    public int Id { get; set; }

    // Person name
    public string Name { get; set; }

    // Person age
    public int Age { get; set; }

    // Virtual method to allow polymorphic behavior
    public virtual string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}";
    }
}
#endregion

#region Derived Classes

// Man class inherits from Person
public class Man : Person
{
    // Specific property for Man
    public string Playing { get; set; }

    // Overriding base class method
    public override string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}, Playing = {Playing}";
    }
}

// Woman class inherits from Person
public class Woman : Person
{
    // Specific property for Woman
    public string Activities { get; set; }

    // Overriding base class method
    public override string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}, Activity = {Activities}";
    }
}

// Child class inherits from Person
public class Child : Person
{
    // Specific property for Child
    public string WatchingCartoon { get; set; }

    // Overriding base class method
    public override string GetDetails()
    {
        return $"Id = {Id}, Name = {Name}, Age = {Age}, Cartoon = {WatchingCartoon}";
    }
}
#endregion

#region Main Program
// Entry point of the application
public class Inheritance
{
    public static void Main(string[] args)
    {
        // Creating Person object
        Person person = new Person
        {
            Id = 1,
            Name = "Arul",
            Age = 20
        };

        // Creating Man object but referencing it as Person (Polymorphism)
        Person man = new Man
        {
            Id = 10,
            Name = "Kumar",
            Age = 24,
            Playing = "Football"
        };

        // Creating Woman object but referencing it as Person
        Person woman = new Woman
        {
            Id = 11,
            Name = "Kumari",
            Age = 23,
            Activities = "Rugby & Home"
        };

        // Creating Child object but referencing it as Person
        Person child = new Child
        {
            Id = 100,
            Name = "Anki",
            Age = 5,
            WatchingCartoon = "Chota Bheem"
        };

        // Calling overridden methods (Runtime Polymorphism)
        Console.WriteLine(person.GetDetails());
        Console.WriteLine(man.GetDetails());
        Console.WriteLine(woman.GetDetails());
        Console.WriteLine(child.GetDetails());
    }
}
#endregion
