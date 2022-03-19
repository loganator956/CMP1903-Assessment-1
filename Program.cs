//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMP1903M_Assessment_1.Debugging;

namespace CMP1903M_Assessment_1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("What type of input would you like to use?\n1 Manual Text Entry\n2 Text File");
            string input = Console.ReadLine();
            int selection = 0;
            if (int.TryParse(input, out selection))
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine($"{Input.ManualTextInput()}");
                        break;
                    case 2:
                        throw new NotImplementedException();
                    default:
                        Debug.LogError($"Unrecognised option {selection}");
                        break;
                }
            }
            else
            {
                Debug.LogError($"Unrecognised input {input}");
                Main();
            }
        }
    }
}
