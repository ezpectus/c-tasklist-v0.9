# c-tasklist-v0.9



**What the Code Does**

1.  **The `Task` Class:**
    * Think of this as a blueprint for a single task. Each task has:
        * `Id`: A unique number to identify the task.
        * `Title`: A short name for the task.
        * `Description`: More details about the task.
        * `IsCompleted`: A "true" or "false" value to show if the task is done.

2.  **The `TaskManager` Class:**
    * This class is like the manager of all your tasks. It can do these things:
        * `AddTask(Task task)`: Adds a new task to the list.
        * `RemoveTask(int taskId)`: Removes a task by its ID.
        * `UpdateTask(int taskId, Task updatedTask)`: Changes an existing task.
        * `GetAllTasks()`: Shows all the tasks in the list.
    * It also saves and loads tasks from a file so you don't lose them when you close the program.

3.  **How Tasks Are Saved:**
    * It uses something called `DataContractSerializer`. This is like a tool that turns your task objects into data that can be stored in a file.
    * The tasks are saved in a file named "tasks.dat".

4.  **The `Main` Function:**
    * This is where the program starts.
    * It creates a `TaskManager` object.
    * It adds two example tasks.
    * It then displays all the tasks.
    * `Console.ReadLine()` makes the program wait for you to press Enter before closing.

**In Simpler Terms**

* `Task`: Like a single note on a sticky note.
* `TaskManager`: Like a notebook that holds all your sticky notes.
* Saving to a file: Like putting your notebook in a safe place.

**Key Points**

* `[Serializable]` on the `Task` class tells the program that it's okay to save these objects to a file.
* `DataContractSerializer` is the tool that does the saving and loading.

This code is a good example of how to make a simple program to manage data. I hope that makes it easier to understand!
