using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class TaskManager
    {
        private static TaskClass currentTask;
        private static List<string> menu = new List<string> { "List Tasks", "Add Task", "Delete Task", "Mark Task Complete", "Search Tasks by Name", "Search Tasks Before Date", "Quit" };
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
                    MarkTaskComplete();
                }
                else if (userSelection == 4)
                {
                    Console.Clear();
                    FindTasksByName();
                }
                else if (userSelection == 5)
                {
                    Console.Clear();
                    FindTasksByDate();
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
            string dueDate = MyLibs.UserInputLibrary.GetNewDate("When is this task due? (mm/dd/yyyy) ");

            TaskList.Add(new TaskClass(assignedTo, description, dueDate));
            Console.WriteLine("Task added successfully");
        }

        public static void DeleteTask()
        {
            int cancelOption = TaskList.Count + 1;
            int userSelection;
            bool actionConfirmation;

            ListTasks();
            Console.WriteLine($"Enter {cancelOption} to cancel.");

            userSelection = MyLibs.UserInputLibrary.GetIntegerResponse("\nWhich task do you wish to delete? ", TaskList.Count + 1);

            while (userSelection < 0 || userSelection > TaskList.Count + 1)
            {
                userSelection = MyLibs.UserInputLibrary.GetMenuSelection("Invalid selection: Which task do you wish to delete? ", Menu);
            }

            if (userSelection == cancelOption - 1)
            {
                Console.Clear();
                return;
            }
            else
            {
                PrintTask(userSelection);
                actionConfirmation = MyLibs.UserInputLibrary.GetYesOrNoInput("Are you sure you want to delete this item");

                if (actionConfirmation)
                {
                    TaskList.RemoveAt(userSelection);
                    Console.Clear();
                    Console.WriteLine("Task deleted successfully");
                }
                else
                {
                    Console.WriteLine("Action canceled");
                }
            }
        }

        public static void MarkTaskComplete()
        {
            int cancelOption = TaskList.Count + 1;
            int userSelection;
            bool actionConfirmation;

            ListTasks();
            Console.WriteLine($"Enter {cancelOption} to cancel.");

            userSelection = MyLibs.UserInputLibrary.GetIntegerResponse("\nWhich task do you wish to mark complete? ", TaskList.Count + 1);

            while (userSelection < 0 || userSelection > TaskList.Count + 1)
            {
                userSelection = MyLibs.UserInputLibrary.GetMenuSelection("Invalid selection: Which task do you wish to mark complete? ", Menu);
            }

            if (userSelection == cancelOption - 1)
            {
                Console.Clear();
                return;
            }
            else
            {
                PrintTask(userSelection);
                actionConfirmation = MyLibs.UserInputLibrary.GetYesOrNoInput("Are you sure you want to mark this item complete");

                if (actionConfirmation)
                {
                    TaskList[userSelection].IsComplete = true;
                    Console.Clear();
                    Console.WriteLine("Task Updated");
                }
                else
                {
                    Console.WriteLine("Action canceled");
                }
            }
        }

        public static void FindTasksByName()
        {
            MyLibs.ConsoleLibrary.DrawTitle($"Find Tasks by Team Member");

            string name = MyLibs.UserInputLibrary.GetName("Which team member's tasks would you like to see? ");

            if (!TeamMemberExists(name))
            {
                Console.WriteLine($"No tasks found for {name}");
            }
            else
            {
                for (int i = 0; i < TaskList.Count; i++)
                {
                    if (TaskList[i].AssignedTo == name)
                    {
                        PrintTask(i);
                    }
                }
            }
        }

        public static void FindTasksByDate()
        {
            MyLibs.ConsoleLibrary.DrawTitle("Find Tasks Due Before a Date");
            DateTime date = DateTime.Parse(MyLibs.UserInputLibrary.GetNewDate("Enter cutoff date: "));

            MyLibs.ConsoleLibrary.DrawTitle($"Tasks Due Before {date.ToShortDateString()}");

            if (!TasksExistBeforeDate(date))
            {
                Console.WriteLine("No matching tasks found\n");
            }
            else 
            {
                for (int i = 0; i < TaskList.Count; i++)
                {
                    if (TaskList[i].DueDate < date)
                    {
                        PrintTask(i);
                    }
                }
            }
        }

        private static bool TasksExistBeforeDate(DateTime date)
        {
            for (int i = 0; i < TaskList.Count; i++)
            {
                if (TaskList[i].DueDate < date)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TeamMemberExists(string name)
        {
            for (int i = 0; i < TaskList.Count; i++)
            {
                if (TaskList[i].AssignedTo == name)
                {
                    return true;
                }
            }

            return false;
        }

        private static void PrintTask(int index)
        {
            Console.WriteLine($"{index + 1}. {TaskList[index].AssignedTo}\t\t{TaskList[index].DueDate.ToShortDateString()}\t{TaskList[index].IsComplete}\t\t{TaskList[index].TaskDescription}");
        }
    }
}
