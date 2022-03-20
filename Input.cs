using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMP1903M_Assessment_1.Debugging;

namespace CMP1903M_Assessment_1
{
    /// <summary>
    /// Handles taking and verifying user input
    /// </summary>
    public static class Input
    {
        //Handles the text input for Assessment 1

        /// <summary>
        /// Gets text input from the keyboard
        /// </summary>
        /// <returns>Returns the the text from keyboard input</returns>
        public static string ManualTextInput()
        {
            string text = "";

            Console.WriteLine("Manual Text Input (Supports multiline using \'\\n\'");
            string inputText = Console.ReadLine();
            if (string.IsNullOrEmpty(inputText)) { return ""; };
            text = inputText.Replace("\\n", "\n");

            if (ShowConfirmDialog(text))
            {
                return text;
            }
            else
            {
                Console.WriteLine("Input your new text");
                return ManualTextInput();
            }
        }

        /// <summary>
        /// Gets the text input from a file
        /// </summary>
        /// <param name="fileName">the name/path to the file to read</param>
        /// <returns>the text within the file</returns>
        public static string FileTextInput(string fileName)
        {
            string text = "";
            throw new NotImplementedException();
            // TODO: Read file
            return text;
        }

        /// <summary>
        /// Shows a confirmation prompt to get the user to confirm their inputs
        /// </summary>
        /// <param name="input">The user's inputted text</param>
        /// <returns>Whether the user confirms or unconfirms their input</returns>
        static bool ShowConfirmDialog(string input)
        {
            Console.WriteLine($"Are you sure about your inputs (Y/n):\n{input}");
            string response = Console.ReadLine();
            // defaults to yes in this case so only check if the user says no
            if (response.Trim().ToLower() == "n")
            {
                return false;
            }
            return true;
        }

    }
}
