using System;
using System.Collections.Generic;
using System.Linq;

class Todo
{
    public string TaskDescription { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsCompleted { get; set; }

    public Todo(string taskDescription)
    {
        TaskDescription = taskDescription;
        CreationTime = DateTime.Now;
        IsCompleted = false;
    }
}

class Program
{
    static List<Todo> tasks = new();

    static void Main()
    {
        Console.Title = "TODO Application";
        Console.Clear();

        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║       Welcome to the TODO application    ║");
        Console.WriteLine("╚══════════════════════════════════════════╝");

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. View Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewTasks();
                    break;
                case "2":
                    AddTask();
                    break;
                case "3":
                    MarkTaskAsCompleted();
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Exiting the TODO application. Goodbye!");
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ViewTasks()
    {
        Console.Clear();
        Console.WriteLine("Tasks:");
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║  #   ║ Task Description                 ║ Status      ║ Created on            ║");
        Console.WriteLine("╠══════╬══════════════════════════════════╬═════════════╬═══════════════════════╣");

        var sortedTasks = tasks
            .OrderBy(t => t.IsCompleted)
            .ThenBy(t => t.CreationTime)
            .ToList();

        if (sortedTasks.Count == 0)
        {
            Console.WriteLine(
                "║                                  No tasks available                                  ║");
        }
        else
        {
            for (int i = 0; i < sortedTasks.Count; i++)
            {
                Console.ForegroundColor = sortedTasks[i].IsCompleted ? ConsoleColor.Green : ConsoleColor.Yellow;
                Console.WriteLine(
                    $"║ {i + 1,2}   ║ {FormatText(sortedTasks[i].TaskDescription, 36)} ║ {(sortedTasks[i].IsCompleted ? "Completed" : "Pending"),11} ║ {sortedTasks[i].CreationTime.ToString("yyyy-MM-dd HH:mm"),19} ║");
                Console.ResetColor();
            }
        }

        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();
    }

    static string FormatText(string text, int length)
    {
        if (text.Length <= length)
        {
            return text.PadRight(length);
        }
        else
        {
            return text.Substring(0, length - 3) + "...";
        }
    }

    static void AddTask()
    {
        Console.Clear();
        Console.WriteLine("Enter a new task:");
        Console.Write(" > ");
        string newTask = Console.ReadLine();
        Todo todo = new Todo(newTask);
        tasks.Add(todo);
        Console.Clear();
        Console.WriteLine("Task added successfully!");
    }

    static void MarkTaskAsCompleted()
    {
        ViewTasks();

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to mark as completed.");
            return;
        }

        Console.Write("Enter the number of the task to mark as completed (or 0 to cancel): ");

        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = true;
            Console.WriteLine($"Marking task '{tasks[taskNumber - 1].TaskDescription}' as completed.");
        }
        else if (taskNumber == 0)
        {
            Console.Clear();
            Console.WriteLine("Marking task as completed canceled.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid task number. Please try again.");
        }
    }

    static string PadText(string text, int length)
    {
        if (text.Length <= length)
        {
            return text.PadRight(length);
        }
        else
        {
            return text.Substring(0, length - 3) + "...";
        }
    }
}