﻿//Base code project for CMP1903M Assessment 1
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
            string input = Console.ReadLine() ?? "0";
            int selection = 0;
            if (int.TryParse(input, out selection))
            {
                Analyse analysis = null;
                switch (selection)
                {
                    case 1:
                        // manual text input
                        analysis = new Analyse(Input.ManualTextInput());
                        break;
                    case 2:
                        analysis = new Analyse(Input.FileTextInput());
                        break;
                    default:
                        Debug.LogError($"Unrecognised option {selection}");
                        Main();
                        break;
                }
                if (analysis != null)
                {
                    analysis.AnalyseText();
                    Console.WriteLine("Text analysed. Would you like to view your report in: \n1. Console (Default)\n2. File");
                    // find out whether the user wants to report to console, file, or both
                    string response = Console.ReadLine() ?? "1"; // Default to view in console, if null
                    bool console = false;
                    bool file = false;
                    foreach (char c in response.Trim())
                    {
                        if (c == '1')
                            console = true;
                        else if (c == '2')
                            file = true;
                        else
                            Debug.LogError($"Unrecognised option: {c.ToString()}");
                    }
                    console = !console && !file; // ensures that the report will go to console if selects neither
                    Report report = new Report(analysis);
                    if (console) { report.ReportToConsole(); };
                    if (file) { report.ReportToFile(); }; // TODO: Add option to choose where the file is saved to?
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
