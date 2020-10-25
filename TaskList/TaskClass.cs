using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
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
