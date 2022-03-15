using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1
{
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

            Console.WriteLine("Manual Text Input (Use * to indicate end of text input)");
            
            while(true)
            {
                string newLine = Console.ReadLine();
                text += newLine + "\n";
                if (newLine.EndsWith('*'))
                {
                    break;
                }
            }
            return text;
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

    }
}
