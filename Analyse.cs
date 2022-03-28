using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMP1903M_Assessment_1.Debugging;

namespace CMP1903M_Assessment_1
{
    /// <summary>
    /// Stores and analyses the user input
    /// </summary>
    public class Analyse
    {
        public Analyse(string text)
        {
            Text = text;
        }

        private const int LongWordThreshold = 7;
        readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

        public string Text { get; private set; }
        public int[] Statistics = new int[5];
        public int[] LetterFrequencies = new int[26]; // add 97 to the index to get the char value

        /// <summary>
        /// Analyses the input text
        /// </summary>
        /// <returns>
        /// Array of statistics:
        /// 0 Sentence Count,
        /// 1 Vowels Count,
        /// 2 Consonants Count,
        /// 3 Upper Case Letters Count,
        /// 4 Lower Case Letters Count
        /// </returns>
        public int[] AnalyseText()
        {
            int[] values = new int[5];

            char[] inputChars = Text.ToCharArray();

            #region sentences
            List<string> sentences = new List<string>();
            string sentenceProgress = "";
            foreach (char c in inputChars)
            {
                if (c == '!' || c == '.' || c == '?')
                {
                    sentences.Add(sentenceProgress);
                    sentenceProgress = "";
                    continue;
                }
                sentenceProgress += c.ToString();
            }
            // string[] sentences = Text.Split('.');
            int sentenceCount = 0;
            foreach (string s in sentences)
            {
                if (s.Trim().Length != 0) { sentenceCount++; };
            }
            values[0] = sentenceCount;
            #endregion

            #region vowels & consonants
            int vowelCount = 0;
            int consonantsCount = 0;
            foreach (char c in inputChars)
            {
                if (Vowels.Contains(Char.ToLower(c)))
                {
                    vowelCount++;
                }
                else if (Char.IsLetter(c)) // not a vowel and not a letter
                {
                    consonantsCount++;
                }
            }
            values[1] = vowelCount;
            values[2] = consonantsCount;
            #endregion

            #region characters
            int[] characterFrequencies = new int[26];
            foreach (char c in inputChars)
            {
                if (Vowels.Contains(Char.ToLower(c)))
                {
                    values[1]++; // vowels
                }
                else if (!Vowels.Contains(Char.ToLower(c)) && Char.IsLetter(c))
                {
                    values[2]++; // consonants
                }
                if (Char.IsUpper(c))
                {
                    values[3]++; // upper case
                }
                else
                {
                    values[4]++; // lower case
                }

                // counting characters
                if (Char.IsLetter(c))
                {
                    characterFrequencies[Convert.ToInt32(Char.ToLower(c)) - 97]++;
                }
            }
            #endregion

            LetterFrequencies = characterFrequencies;
            Statistics = values;
            return values;
        }


        /// <summary>
        /// Gathers list of long words from the text input
        /// </summary>
        /// <returns>List of strings of each long word</returns>
        public List<string> GetLongWords()
        {
            List<string> longWordsList = new List<string>();

            string wordProgress = "";
            foreach (char c in Text.ToCharArray())
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    // not a letter so split the word
                    if (wordProgress.Length > LongWordThreshold)
                    {
                        // word is long
                        longWordsList.Add(wordProgress);
                    }
                    wordProgress = "";
                    continue;
                }
                wordProgress += c.ToString();
            }

            return longWordsList;
        }
    }
}
