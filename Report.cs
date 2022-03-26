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
    /// Handles reporting/presenting the resulting data to the user
    /// </summary>
    class Report
    {
        public Report(Analyse analysis)
        {
            Analysis = analysis;
            _reportText = GenerateReportText();
        }
        public Analyse Analysis { get; private set; }
        string _reportText = string.Empty;

        /// <summary>
        /// Generates the report text from the analysis
        /// </summary>
        /// <returns>Report text</returns>
        private string GenerateReportText()
        {
            string text = (@$"Analysis of Input:
    Number of sentences:            {Analysis.Statistics[0]}
    Number of vowels:               {Analysis.Statistics[1]}
    Number of consonants:           {Analysis.Statistics[2]}
    Number of upper case letters:   {Analysis.Statistics[3]}
    Number of lower case letters:   {Analysis.Statistics[4]}
Now for letter frequences:");
            for (int i = 0; i < Analysis.LetterFrequencies.Length; i++)
            {
                char c = (char)(i + 97);
                text += $"\n\t{c.ToString()}:\t{Analysis.LetterFrequencies[i].ToString()}";
            }
            return text;
        }

        public void ReportToConsole()
        {
            Console.WriteLine(_reportText);
        }

        private const string DefaultReportFilePath = "report.txt";

        public void ReportToFile()
        {
            ReportToFile(DefaultReportFilePath);
        }

        public void ReportToFile(string outputPath)
        {
            Console.WriteLine("Saving report to file");
            try
            {
                File.WriteAllText(outputPath, _reportText);
                Console.WriteLine($"Successfully saved report to the file {outputPath}");
                Console.WriteLine("Checking long words");
                List<string> longWords = Analysis.GetLongWords();
                if (longWords.Count > 0)
                {
                    Console.WriteLine("Saving long words file");
                    File.WriteAllLines("longwords.txt", longWords.ToArray());
                    Console.WriteLine("Successfully saved long words to file :)");
                }
            }
            catch (Exception except)
            {
                Debug.LogError(except.Message);
                Debug.LogError("Saving the file had errors :( Exception message above.");
            }
        }
    }
}
