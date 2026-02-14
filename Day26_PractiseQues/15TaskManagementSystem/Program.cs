using System;

namespace TaskManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Management System");
            var taskManager = new TaskManager();

            // Create projects
            taskManager.CreateProject("Website Redesign", "John Manager", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(30));
            taskManager.CreateProject("Mobile App", "Jane Manager", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(60));
            taskManager.CreateProject("Data Migration", "Bob Manager", DateTime.Now.AddDays(0), DateTime.Now.AddDays(45));

            // Add tasks to projects
            taskManager.AddTask(1, "Design Homepage", "Create new homepage design", "High", DateTime.Now.AddDays(5), "Alice");
            taskManager.AddTask(1, "Setup Database", "Configure production database", "High", DateTime.Now.AddDays(3), "Charlie");
            taskManager.AddTask(1, "Testing", "QA testing for homepage", "Medium", DateTime.Now.AddDays(8), "Diana");
            taskManager.AddTask(1, "Deploy", "Deploy to production", "Low", DateTime.Now.AddDays(10), "Eve");

            taskManager.AddTask(2, "UI Design", "Design mobile app UI", "High", DateTime.Now.AddDays(-2), "Alice");
            taskManager.AddTask(2, "API Development", "Develop REST API", "High", DateTime.Now.AddDays(15), "Frank");
            taskManager.AddTask(2, "Integration Testing", "Test API integration", "Medium", DateTime.Now.AddDays(20), "Grace");

            taskManager.AddTask(3, "Data Audit", "Audit existing data", "Medium", DateTime.Now.AddDays(7), "Henry");
            taskManager.AddTask(3, "Migration Script", "Write migration scripts", "High", DateTime.Now.AddDays(12), "Ivy");
            taskManager.AddTask(3, "Validation", "Validate migrated data", "Medium", DateTime.Now.AddDays(25), "Jack");

            // Display tasks by priority
            Console.WriteLine("Tasks by Priority:");
            var grouped = taskManager.GroupTasksByPriority();
            var priorityOrder = new[] { "High", "Medium", "Low" };
            foreach (var priority in priorityOrder)
            {
                if (grouped.ContainsKey(priority))
                {
                    Console.WriteLine($"\n{priority}:");
                    foreach (var task in grouped[priority])
                    {
                        Console.WriteLine($"  - {task.Title} (Assigned to: {task.AssignedTo}, Due: {task.DueDate:yyyy-MM-dd})");
                    }
                }
            }

            // Display overdue tasks
            Console.WriteLine("\nOverdue Tasks:");
            var overdueTasks = taskManager.GetOverdueTasks();
            if (overdueTasks.Count == 0)
            {
                Console.WriteLine("No overdue tasks!");
            }
            else
            {
                foreach (var task in overdueTasks)
                {
                    Console.WriteLine($"  - {task.Title} (Assigned to: {task.AssignedTo}, Due: {task.DueDate:yyyy-MM-dd}, Status: {task.Status})");
                }
            }

            // Display tasks by assignee
            Console.WriteLine("\nTasks Assigned to Alice:");
            var aliceTasks = taskManager.GetTasksByAssignee("Alice");
            foreach (var task in aliceTasks)
            {
                Console.WriteLine($"  - {task.Title} (Priority: {task.Priority}, Due: {task.DueDate:yyyy-MM-dd})");
            }
        }
    }
}
