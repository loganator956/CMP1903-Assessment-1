using System;
using System.IO;
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
    public static class Input // felt like this should be static rather than an instance
    {
        /// <summary>
        /// Gets text input from the keyboard
        /// </summary>
        /// <returns>Returns the the text from keyboard input</returns>
        public static string ManualTextInput()
        {
            string text = "";

            // TODO: Use * to end the input
            Console.WriteLine("Manual Text Input (Supports multiline using \'\\n\')");
            string inputText = Console.ReadLine() ?? string.Empty;
            // interpreting some escape characters in the user's input
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
        /// Prompts user for a path to file and then reads the text from it
        /// </summary>
        /// <returns>The string contents of the text file</returns>
        public static string FileTextInput()
        {
            const string DefaultFilePath = "text.txt";

            Console.WriteLine($"Enter the file name to read. (Default: '{DefaultFilePath}')");
            string response = Console.ReadLine() ?? DefaultFilePath;

            string filePath = string.Empty;

            if (string.IsNullOrEmpty(response)) // still exists since want to check that string is not empty string
            {
                // user responded with nothing, use default
                filePath = DefaultFilePath;
            }
            else
            {
                // user inputted something, pass the input
                filePath = response;
            }
            return FileTextInput(filePath);
        }

        /// <summary>
        /// Gets the text input from a file
        /// </summary>
        /// <param name="fileName">the name/path to the file to read</param>
        /// <returns>the text within the file</returns>
        public static string FileTextInput(string fileName)
        {
            string text = string.Empty;

            // make sure the file exists before attempting to access it
            if (!File.Exists(fileName))
            {
                Debug.LogError($"File not found at {fileName}");
                Console.WriteLine("Try inputting a correct path");
                return FileTextInput();
            }
            try
            {
                string fileContents = File.ReadAllText(fileName);
                text = fileContents;
            }
            catch (Exception except)
            {
                Debug.LogError(except.Message);
            }

            return text;
        }

        /// <summary>
        /// Shows a confirmation prompt to get the user to confirm their inputs
        /// </summary>
        /// <param name="input">The user's inputted text</param>
        /// <returns>Whether the user confirms or unconfirms their input</returns>
        static bool ShowConfirmDialog(string input)
        {
            Console.WriteLine($"You entered:\n{input}\nAre you sure about your inputs [Y/n]?");
            string response = Console.ReadLine() ?? "y";
            // defaults to yes in this case so only check if the user says no
            if (response.Trim().ToLower() == "n")
            {
                return false;
            }
            return true;
        }

    }
}
