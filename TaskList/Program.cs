using System;

namespace TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager.TaskList.Add(new TaskClass("Nick Hickman", "Task Manager capstone", "10/26/2020"));
            TaskManager.TaskList.Add(new TaskClass("Nick Hickman", "Movie List lab", "10/26/2020"));
            TaskManager.TaskList.Add(new TaskClass("Nick Hickman", "Mock Assessment 2", "10/26/2020"));
            TaskManager.TaskList.Add(new TaskClass("Ricky Bobby", "Be first, not last", "10/31/2020"));
            TaskManager.TaskList.Add(new TaskClass("Hiphopanonymous", "Do the thing", "11/25/2020"));
            TaskManager.Start();
        }
    }
}
