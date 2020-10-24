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
            new TaskClass("Nick Hickman", "Task Manager Capstone", DateTime.Parse("10/26/2020")),
            new TaskClass("Nick Hickman", "Movie List Lab", DateTime.Parse("10/26/2020")),
            new TaskClass("Nick Hickman", "Mock Assessment 2", DateTime.Parse("10/26/2020")),
            new TaskClass("Nick Hickman", "Blockbuster Lab", DateTime.Parse("10/27/2020"))
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
                MyLibs.ConsoleLibrary.DrawTitle("Task Manager", "program");
                MyLibs.ConsoleLibrary.DrawTitle("Menu", "section");

                ListMenuOptions();

                int userSelection = MyLibs.UserInputLibrary.ValidateMenuSelection("\nWhat would you like to do? ", Menu);

                if (userSelection == 0)
                {
                    ListTasks();
                }
                else if (userSelection == 1)
                {
                    AddTask();
                }
                else if (userSelection == 2)
                {
                    DeleteTask();
                }
                else if (userSelection == 3)
                {
                    DeleteTask();
                }

                if (!MyLibs.UserInputLibrary.UserWantsToContinue("Keep Going?", "I didn't understand that."))
                {
                    Console.WriteLine("Thanks, see you next time!");
                    break;
                }
                Console.Clear();
            }
        }

        public static void ListTasks()
        {
            Console.Clear();

            MyLibs.ConsoleLibrary.DrawTitle("Assigned To  |  Due Date  |  Description", "section");

            for (int i = 0; i < TaskList.Count; i++)
            {
                PrintTask(i);
            }
        }

        public static void AddTask()
        {
            MyLibs.ConsoleLibrary.DrawTitle("Add Task", "program");

            string assignedTo = MyLibs.UserInputLibrary.GetUserResponse("Who will this task be assigned to? ");
            string description = MyLibs.UserInputLibrary.GetUserResponse("Enter a task description: ");
            DateTime dueDate = DateTime.Parse(MyLibs.UserInputLibrary.GetUserResponse("When is this task due? "));

            TaskList.Add(new TaskClass(assignedTo, description, dueDate));
        }

        public static void DeleteTask()
        {
            MyLibs.ConsoleLibrary.DrawTitle("Delete Task", "program");
            ListTasks();

            int userSelection = MyLibs.UserInputLibrary.ValidateMenuSelection("\nWhich item should be deleted? ", Menu);

            while (userSelection < 0 || userSelection > TaskList.Count)
            {
                userSelection = MyLibs.UserInputLibrary.ValidateMenuSelection("Invalid selection: Which item should be deleted? ", Menu);
            }

            PrintTask(userSelection);
            string deleteConfirmation = MyLibs.UserInputLibrary.GetUserResponse("Are you sure you want to delete this item? (y/n) ");

            if (deleteConfirmation == "y")
            {
                TaskList.RemoveAt(userSelection);
                Console.WriteLine("Task successfully removed!");
            }
            else if (deleteConfirmation == "n")
            {
                Console.WriteLine("Task deletion canceled");
            }

        }

        public static void MarkComplete()
        {
            MyLibs.ConsoleLibrary.DrawTitle("Mark item complete", "program");
            ListTasks();

            int userSelection = MyLibs.UserInputLibrary.ValidateMenuSelection("\nWhich item should be marked complete? ", Menu);

            while (userSelection < 0 || userSelection > TaskList.Count)
            {
                userSelection = MyLibs.UserInputLibrary.ValidateMenuSelection("Invalid selection: Which item should be marked complete? ", Menu);
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
            Console.WriteLine($"{index + 1}. {TaskList[index].AssignedTo}\t{TaskList[index].DueDate}\t{TaskList[index].TaskDescription}");
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

        public TaskClass(string AssignedTo, string TaskDescription, DateTime DueDate)
        {
            assignedTo = AssignedTo;
            taskDescription = TaskDescription;
            dueDate = DueDate;
            isComplete = false;
        }


    }
}
