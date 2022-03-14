using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1
{
    public class Input
    {
        //Handles the text input for Assessment 1
        
        /// <summary>
        /// Gets text input from the keyboard
        /// </summary>
        /// <returns>Returns the the text from keyboard input</returns>
        public string ManualTextInput()
        {
            string text = "";
            // TODO: Add multiline input support
            text = Console.ReadLine();
            return text;
        }

        /// <summary>
        /// Gets the text input from a file
        /// </summary>
        /// <param name="fileName">the name/path to the file to read</param>
        /// <returns>the text within the file</returns>
        public string FileTextInput(string fileName)
        {
            string text = "";
            throw new NotImplementedException();
            // TODO: Read file
            return text;
        }

    }
}
