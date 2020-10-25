using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class TaskManager
    {
        private static TaskClass currentTask;
        private static List<string> menu = new List<string> { "List Tasks", "Add Task", "Delete Task", "Mark Task Complete", "Quit" };
        private static List<TaskClass> taskList = new List<TaskClass>
        {
            new TaskClass("Nick Hickman", "Task Manager Capstone", "10/26/2020"),
            new TaskClass("Nick Hickman", "Movie List Lab", "10/26/2020"),
            new TaskClass("Nick Hickman", "Mock Assessment 2", "10/26/2020"),
            new TaskClass("Nick Hickman", "Blockbuster Lab", "10/27/2020")
        };

        public static TaskClass CurrentTask
        {
            get { return currentTask; }
            set { currentTask = value;  }
        }
        public static List<string> Menu
        {
            get { return menu; }
        }
        public static List<TaskClass> TaskList
        { 
            get { return taskList; }
            set { TaskList = value; }
        }

        public TaskManager()
        {
            TaskList = new List<TaskClass>();
            CurrentTask = null;
        }

        public static void ListMenuOptions()
        {
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i]}");
            }
        }

        public static void Start()
        {
            while (true)
            {
                MyLibs.ConsoleLibrary.DrawTitle("Menu");

                ListMenuOptions();

                int userSelection = MyLibs.UserInputLibrary.GetMenuSelection("\nWhat would you like to do? ", Menu);

                if (userSelection == 0)
                {
                    Console.Clear();
                    ListTasks();
                }
                else if (userSelection == 1)
                {
                    Console.Clear();
                    AddTask();
                }
                else if (userSelection == 2)
                {
                    Console.Clear();
                    DeleteTask();
                }
                else if (userSelection == 3)
                {
                    Console.Clear();
                    MyLibs.ConsoleLibrary.DrawTitle("Mark Task Complete");
                    DeleteTask();
                }
                else 
                {
                    Console.WriteLine("Thanks, see you next time!");
                    break;
                }
            }
        }

        public static void ListTasks()
        {
            Console.WriteLine("   Assigned To\t\tDue Date\tComplete\tDescription");
            MyLibs.ConsoleLibrary.DrawHr(80);

            for (int i = 0; i < TaskList.Count; i++)
            {
                PrintTask(i);
            }

            Console.WriteLine("");
        }

        public static void AddTask()
        {
            MyLibs.ConsoleLibrary.DrawTitle("New Task");

            string assignedTo = MyLibs.UserInputLibrary.GetName("Who will this task be assigned to? ");
            string description = MyLibs.UserInputLibrary.GetUserResponse("Enter a task description: ");
            string dueDate = MyLibs.UserInputLibrary.GetNewDate("When is this task due? ");

            TaskList.Add(new TaskClass(assignedTo, description, dueDate));
            Console.WriteLine("Task added successfully");
        }

        public static void DeleteTask()
        {
            ListTasks();

            int userSelection = MyLibs.UserInputLibrary.GetMenuSelection("\nWhich task do you wish to delete? ", Menu);

            while (userSelection < 0 || userSelection > TaskList.Count)
            {
                userSelection = MyLibs.UserInputLibrary.GetMenuSelection("Invalid selection: Which task do you wish to delete? ", Menu);
            }

            PrintTask(userSelection);
            bool deleteConfirmation = MyLibs.UserInputLibrary.GetYesOrNoInput("Are you sure you want to delete this item");

            if (deleteConfirmation)
            {
                TaskList.RemoveAt(userSelection);
                Console.WriteLine("Task deleted successfully");
            }
            else {
                Console.WriteLine("Action canceled");
            }

        }

        public static void MarkComplete()
        {
            ListTasks();

            int userSelection = MyLibs.UserInputLibrary.GetMenuSelection("\nWhich item should be marked complete? ", Menu);

            while (userSelection < 0 || userSelection > TaskList.Count)
            {
                userSelection = MyLibs.UserInputLibrary.GetMenuSelection("Invalid selection: Which item should be marked complete? ", Menu);
            }

            PrintTask(userSelection);
            string actionConfirmation = MyLibs.UserInputLibrary.GetUserResponse("Are you sure you want to mark this item complete? (y/n) ");

            if (actionConfirmation == "y")
            {
                TaskList[userSelection].IsComplete = true;
                Console.WriteLine("Task successfully removed!");
            }
            else if (actionConfirmation == "n")
            {
                Console.WriteLine("Action canceled");
            }
        }

        private static void PrintTask(int index)
        {
            Console.WriteLine($"{index + 1}. {TaskList[index].AssignedTo}\t\t{TaskList[index].DueDate.ToShortDateString()}\t{TaskList[index].IsComplete}\t\t{TaskList[index].TaskDescription}");
        }
    }

    public class TaskClass
    {
        private string assignedTo;
        private string taskDescription;
        private DateTime dueDate;
        private bool isComplete;

        public string AssignedTo
        {
            get { return assignedTo; }
            set { assignedTo = value; }
        }

        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; }
        }

        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }

        public bool IsComplete
        {
            get { return isComplete; }
            set { isComplete = value; }
        }

        public TaskClass(string AssignedTo, string TaskDescription, string DueDate)
        {
            assignedTo = AssignedTo;
            taskDescription = TaskDescription;
            dueDate = DateTime.Parse(DueDate);
            isComplete = false;
        }
    }
}
