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
        private string _text = string.Empty;
        public string Text
        {
            get { return _text; }
            private set { _text = value; }
        }

        public Analyse(string text)
        {
            Text = text;
        }

        readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u' };

        /*
        0. Sentence Count
        1. Vowels Count
        2. Sonsonants Count
        3. Upper Case Letters Count
        4. Lower Case Letters Count
        */
        public int[] Statistics = new int[5];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
                else
                {
                    consonantsCount++;
                }
            }
            values[1] = vowelCount;
            values[2] = consonantsCount;
            #endregion

            #region cases
            int upperCount = 0;
            int lowerCount = 0;
            foreach (char c in inputChars)
            {
                if (Char.IsUpper(c))
                {
                    upperCount++;
                }
                else
                {
                    lowerCount++;
                }
            }
            values[3] = upperCount;
            values[4] = lowerCount;
            #endregion

            // TODO: Count freq. of characters and stuff

            // TODO: Gather long-words thing (READ BRIEF)

            Statistics = values;
            return values;
        }
    }
}
