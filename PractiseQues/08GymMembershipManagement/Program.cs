using System;

namespace GymMembershipManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Gym Membership Management System");
            var gymManager = new GymManager();

            // Add members
            gymManager.AddMember("John Doe", "Basic", 3);
            gymManager.AddMember("Jane Smith", "Premium", 6);
            gymManager.AddMember("Bob Johnson", "Platinum", 12);
            gymManager.AddMember("Alice Brown", "Basic", 3);
            gymManager.AddMember("Charlie Davis", "Premium", 6);

            // Add classes
            gymManager.AddClass("Yoga", "Sarah", DateTime.Now.AddDays(2), 15);
            gymManager.AddClass("CrossFit", "Mike", DateTime.Now.AddDays(3), 20);
            gymManager.AddClass("Zumba", "Maria", DateTime.Now.AddDays(5), 25);

            // Register members for classes
            Console.WriteLine("Registering Members for Classes:");
            bool reg1 = gymManager.RegisterForClass(1001, "Yoga");
            Console.WriteLine($"John registered for Yoga: {(reg1 ? "Success" : "Failed")}");

            bool reg2 = gymManager.RegisterForClass(1002, "Yoga");
            Console.WriteLine($"Jane registered for Yoga: {(reg2 ? "Success" : "Failed")}");

            bool reg3 = gymManager.RegisterForClass(1003, "CrossFit");
            Console.WriteLine($"Bob registered for CrossFit: {(reg3 ? "Success" : "Failed")}");

            // Display members by membership type
            Console.WriteLine("\nMembers by Membership Type:");
            var grouped = gymManager.GroupMembersByMembershipType();
            foreach (var type in grouped)
            {
                Console.WriteLine($"\n{type.Key}:");
                foreach (var member in type.Value)
                {
                    Console.WriteLine($"  - {member.Name} (ID: {member.MemberId}, Expires: {member.ExpiryDate:yyyy-MM-dd})");
                }
            }

            // Display upcoming classes
            Console.WriteLine("\nUpcoming Classes (Next 7 Days):");
            var upcomingClasses = gymManager.GetUpcomingClasses();
            foreach (var fitnessClass in upcomingClasses)
            {
                Console.WriteLine($"{fitnessClass.ClassName} - {fitnessClass.Schedule:yyyy-MM-dd HH:mm}");
                Console.WriteLine($"  Instructor: {fitnessClass.Instructor} | Registered: {fitnessClass.RegisteredMembers.Count}/{fitnessClass.MaxParticipants}");
            }
        }
    }
}
