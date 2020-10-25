using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyLibs
{
    public class UserInputLibrary
    {
        public static string GetUserResponse(string prompt)
        {
            string userResponse;

            Console.Write(prompt);
            userResponse = Console.ReadLine().Trim();

            while (String.IsNullOrEmpty(userResponse))
            {
                Console.WriteLine("I need you to enter something. Silence isn't a virtue here!");
                userResponse = GetUserResponse(prompt);
            }

            return userResponse;
        }

        public static int GetIntegerResponse(string prompt, int max)
        {
            string userResponse = GetUserResponse(prompt);
            int integer;

            while (!IsInteger(userResponse) || int.Parse(userResponse) > max)
            {
                userResponse = GetUserResponse($"I need a numerical response. {prompt}");
            }

            integer = int.Parse(userResponse);
            integer--;

            return integer;
        }

        public static int GetMenuSelection(string prompt, List<string> options)
        {
            string userResponse = GetUserResponse(prompt);
            int selection;

            while (!IsInteger(userResponse))
            {
                userResponse = GetUserResponse($"I need a numerical response. 1-{options.Count + 1} {prompt}");
            }

            selection = int.Parse(userResponse);
            selection--;

            while (!OptionExists(selection, options))
            {
                selection = GetMenuSelection($"Invalid entry. {prompt}", options);
            }

            return selection;
        }

        public static bool GetYesOrNoInput(string prompt)
        {
            string response = GetUserResponse($"{prompt}? (y/n) ").ToLower();

            while (response != "y" && response != "n")
            {
                response = GetUserResponse($"Invalid response. {prompt} (y/n) ").ToLower();
            }

            if (response == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetName(string prompt)
        {
            string name = GetUserResponse(prompt);

            while (!IsValidName(name))
            {
                name = GetUserResponse($"Invalid name. Names must begin with a capital letter and be at least 2 characters. {prompt}");
            }

            return name;
        }

        public static string GetNewDate(string prompt)
        {
            string dateString = GetUserResponse(prompt);

            while (!IsValidDate(dateString))
            {
                dateString = GetUserResponse($"Invalid date. {prompt} ");
            }

            return dateString;
        }

        public static bool IsInteger(string response)
        {
            return response.All(char.IsDigit);
        }

        public static bool OptionExists(int selection, List<string> options)
        {
            return selection >= 0 && selection < options.Count;
        }

        public static bool IsValidDate(string name)
        {
            Regex rx = new Regex(@"[0-9]{2}[-|\/]{1}[0-9]{2}[-|\/]{1}[0-9]{4}");

            return rx.IsMatch(name);
        }

        public static bool IsValidName(string name)
        {
            Regex rx = new Regex(@"^[A-Z][a-z]{1,30}");

            return rx.IsMatch(name);
        }

        public static bool UserWantsToContinue(string originalQuery, string errorMessage)
        {
            string userResponse = GetUserResponse($"{originalQuery} (y/n)").ToLower(); ;

            while (userResponse != "n" && userResponse != "y")
            {
                userResponse = GetUserResponse($"{errorMessage} {originalQuery} (y/n)").ToLower();
            }

            if (userResponse == "n")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class ConsoleLibrary
    {
        public static void DrawTitle(string title)
        {
            string hr = new string('-', title.Length);
            Console.WriteLine(title);
            Console.WriteLine(hr);
        }
        public static void DrawHr(int length)
        {
            string hr = new string('-', length);
            Console.WriteLine(hr);
        }
    }
}
