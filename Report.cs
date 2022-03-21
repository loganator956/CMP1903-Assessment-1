using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1
{
    /// <summary>
    /// Handles reporting/presenting the resulting data to the user
    /// </summary>
    static class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)

        public static void ReportToConsole(Analyse analysis)
        {
            Console.WriteLine(GenerateReportText(analysis));
        }

        private static string GenerateReportText(Analyse analysis)
        {
            return (@$"Analysis of Input:
            Number of sentences: {analysis.Statistics[0]}
            Number of vowels: {analysis.Statistics[1]}
            Number of consonants: {analysis.Statistics[2]}
            Number of upper case letters: {analysis.Statistics[3]}
            Number of lower case letters: {analysis.Statistics[4]}");
        }

        private const string DefaultReportFilePath = "report.txt";

        public static void ReportToFile(Analyse analysis)
        {
            ReportToFile(analysis, DefaultReportFilePath);
        }

        public static void ReportToFile(Analyse analysis, string outputPath)
        {

        }
    }
}
