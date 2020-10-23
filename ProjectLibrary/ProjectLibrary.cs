using System;
using System.Runtime.InteropServices.ComTypes;

namespace ProjectLibrary
{
    public class TaskMaster
    {
        public static void Start()
        {
            while (true)
            {
                string userSelection = MyLibs.UserInputLibrary.ValidateUserResponse("What would you like to do? (search/add/quit)", "add", "quit");

                Console.WriteLine($"You have selected: {userSelection}");

                if (!MyLibs.UserInputLibrary.UserWantsToContinue("Keep Going?", "I didn't understand that."))
                {
                    Console.WriteLine("Thanks, see you next time!");
                    break;
                }
            }
        }
    }
}
