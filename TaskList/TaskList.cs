using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class TaskManager
    {
        private static TaskClass currentTask;
        private static List<string> menu = new List<string> { "List Tasks", "Add Task", "Delete Task", "Mark Task Complete", "Quit" };
        private static List<TaskClass> taskList = new List<TaskClass> { };

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

                int userSelection = MyLibs.UserInputLibrary.ValidateMenuSelection("\nWhat would you like to do?", Menu);

                if (userSelection == 0)
                {
                    ListTasks();
                }
                else
                {
                    Console.WriteLine($"You have selected: {Menu[userSelection]}");
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

            //foreach (TaskClass task in TaskList)
            //{
            //    Console.WriteLine($);
            //}
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
