using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace TaaskManager { 
public class TaskManager
{
    private List<Task> tasks;
    private string filePath;

    public TaskManager(string filePath)
    {
        this.filePath = filePath;
        tasks = LoadTasks();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
        SaveTasks();
    }

    public void RemoveTask(int taskId)
    {
        tasks.RemoveAll(t => t.Id == taskId);
        SaveTasks();
    }

    public void UpdateTask(int taskId, Task updatedTask)
    {
        int index = tasks.FindIndex(t => t.Id == taskId);
        if (index != -1)
        {
            tasks[index] = updatedTask;
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Task not found.");
        }
    }

    public void GetAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Id: {task.Id}, Title: {task.Title}, Description: {task.Description}, Completed: {task.IsCompleted}");
        }
    }

    private void SaveTasks()
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            var serializer = new DataContractSerializer(typeof(List<Task>));
            serializer.WriteObject(fs, tasks);
        }
    }

    private List<Task> LoadTasks()
    {
        if (File.Exists(filePath))
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                var serializer = new DataContractSerializer(typeof(List<Task>));
                List<Task>? tasks1 = serializer.ReadObject(fs) as List<Task>;
                return tasks;
            }
        }
        else
        {
            return new List<Task>();
        }
    }
}

[Serializable]
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(int id, string title, string description, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        IsCompleted = isCompleted;
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager("tasks.dat");

        // Пример использования
        taskManager.AddTask(new Task(1, "Заголовок 1", "Описание задачи 1", false));
        taskManager.AddTask(new Task(2, "Заголовок 2", "Описание задачи 2", true));

        taskManager.GetAllTasks();

        Console.ReadLine();
    }
}

}
