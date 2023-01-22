using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Lab4.Exercises.Task6
{
    class TaskUtils
    {
        /// <summary>
        /// Finds the longest word in the line
        /// </summary>
        /// <param name="line">String of data</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <returns>Returns the longest word in the line</returns>
        private static string LongestWord(string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            string longestWord = "";
            foreach (string word in parts)
            {
                if (word.Length > longestWord.Length)
                    longestWord = word;
            }
            return longestWord;
        }
        /// <summary>
        /// Removes vowels from the given word.
        /// </summary>
        /// <param name="line">Word with possible vowels</param>
        /// <param name="vowels">vowels of the alphabet</param>
        /// <returns></returns>
        private static StringBuilder RemoveVowels(string line, string vowels)
        {
            StringBuilder newLine = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                if (vowels.IndexOf(line[i]) == -1)
                    newLine.Append(line[i]);
            }
            return newLine;
        }
        /// <summary>
        /// Reads file, removes vowels from the longest word, creates files of results and of information.
        /// </summary>
        /// <param name="fin">Name of data file</param>
        /// <param name="fout">Name of result file</param>
        /// <param name="finfo">NAme of informative file</param>
        /// <param name="punctuation">Punctuation marks to seaparate words</param>
        /// <param name="vowels">Vowels of the alphabet</param>
        public static void Process (string fin, string fout, string finfo, char[] punctuation, string vowels)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            string dashes = new string('-', 38);
            using (var writerF = File.CreateText(fout))
            {
                using (var writerI = File.CreateText(finfo))
                {
                    writerI.WriteLine(dashes);
                    writerI.WriteLine("| Ilgiausias žodis | Pradžia | Ilgis |");
                    writerI.WriteLine(dashes);
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string longestWord = LongestWord(line, punctuation);
                            string wordNoVowels = RemoveVowels(longestWord, vowels).ToString();
                            writerI.WriteLine("| {0,-16} | {1, 7:d} | {2, 5:d} |", longestWord, line.IndexOf(longestWord), longestWord.Length);
                            string newLine = line.Replace(longestWord, wordNoVowels);
                            // The shortest word cannot be replaced this way.
                            // It can be a part of the other word; solution is 4.5 subsection.
                            writerF.WriteLine(newLine);
                        }
                        writerF.WriteLine(line);
                        writerI.WriteLine(dashes);
                    }
                }
            }

        }
    }
}
