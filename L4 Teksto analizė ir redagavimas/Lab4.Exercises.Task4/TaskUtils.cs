using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;

namespace Lab4.Exercises.Task4
{
    class TaskUtils
    {
        /// <summary>
        /// Reads file and finds the number of words having same the first and the last letters.
        /// </summary>
        /// <param name="CFd">Name of data file</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <returns>Returns the number of words having same the first and the last letters</returns>
        public static int Process(string CFd, char[] punctuation)
        {
            string[] lines = File.ReadAllLines(CFd, Encoding.UTF8);
            int equal = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                    equal += FirstEqualLast(line, punctuation);
            }
            return equal;
        }
        /// <summary>
        /// Splits line into words and counts the words having same the first and the last letters.
        /// </summary>
        /// <param name="line">String of data</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <returns>Returns the number of words having same the first and the last letters</returns>
        private static int FirstEqualLast (string line, char[] punctuation)
        {
            string[] parts = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            int equal = 0;
            foreach (string word in parts)
            {
                if (Char.ToLower(word[0]) == Char.ToLower(word[word.Length - 1]))
                    equal++;
            }
            return equal;
        }
        /// <summary>
        /// Reads file and finds the number of words having same the first and the last letters.
        /// </summary>
        /// <param name="CFd">Name of data file</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <returns>Returns the number of words having same the first and the last letters</returns>
        public static int Process(string CFd, string punctuation)
        {
            string[] lines = File.ReadAllLines(CFd, Encoding.UTF8);
            int equal = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                    equal += FirstEqualLast(line, punctuation);
            }
            return equal;
        }

        public static int FirstEqualLast(string line, string punctuation)
        {
            string[] parts = Regex.Split(line, punctuation);
            int equal = 0;
            foreach (string word in parts)
            {
                if (word.Length > 0)    // empty words at the end of line
                {
                    if (Char.ToLower(word[0]) == Char.ToLower(word[word.Length - 1]))
                    {
                        Console.WriteLine("{0} | {1}", word[0], word[word.Length - 1]);
                        equal++;
                    }
                }
            }
            return equal;
        }
    }
}
