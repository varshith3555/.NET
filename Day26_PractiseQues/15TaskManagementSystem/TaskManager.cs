using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagementSystem
{
    public class TaskManager
    {
        private List<Project> projects = new List<Project>();
        private int projectIdCounter = 1;
        private int taskIdCounter = 1;

        public void CreateProject(string name, string manager, DateTime start, DateTime end)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Project name cannot be empty.");

            projects.Add(new Project
            {
                ProjectId = projectIdCounter++,
                ProjectName = name,
                ProjectManager = manager,
                StartDate = start,
                EndDate = end
            });
        }

        public void AddTask(int projectId, string title, string description, string priority, DateTime dueDate, string assignee)
        {
            var project = projects.FirstOrDefault(p => p.ProjectId == projectId);
            if (project == null)
                throw new Exception("Project not found.");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Task title cannot be empty.");

            project.Tasks.Add(new TaskItem
            {
                TaskId = taskIdCounter++,
                Title = title,
                Description = description,
                Priority = priority,
                Status = "ToDo",
                DueDate = dueDate,
                AssignedTo = assignee
            });
        }

        public Dictionary<string, List<TaskItem>> GroupTasksByPriority()
        {
            var grouped = new Dictionary<string, List<TaskItem>>();
            foreach (var project in projects)
            {
                foreach (var task in project.Tasks)
                {
                    if (!grouped.ContainsKey(task.Priority))
                        grouped[task.Priority] = new List<TaskItem>();
                    grouped[task.Priority].Add(task);
                }
            }
            return grouped;
        }

        public List<TaskItem> GetOverdueTasks()
        {
            var allTasks = new List<TaskItem>();
            foreach (var project in projects)
            {
                allTasks.AddRange(project.Tasks);
            }

            return allTasks.Where(t => t.DueDate < DateTime.Now && t.Status != "Completed").ToList();
        }

        public List<TaskItem> GetTasksByAssignee(string assigneeName)
        {
            var allTasks = new List<TaskItem>();
            foreach (var project in projects)
            {
                allTasks.AddRange(project.Tasks.Where(t => t.AssignedTo == assigneeName));
            }
            return allTasks;
        }
    }
}
