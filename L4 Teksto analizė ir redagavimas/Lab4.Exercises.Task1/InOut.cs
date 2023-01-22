using System;
using System.Collections.Generic;
using System.Text;

using System.IO;    // For reading and writing files

namespace Lab4.Exercises.Task1
{
    static class InOut
    {
        /// <summary>
        /// Prints repetition of letters using two columns into a given file.
        /// </summary>
        /// <param name="CFr">Name of the file for the output</param>
        /// <param name="letters">Object having letters and their repetitions</param>
        public static void PrintRepetitions(string CFr, LettersFrequency letters)
        {
            using (var writer = File.CreateText(CFr))
            {
                for (char ch = 'a'; ch <= 'z'; ch++)
                {
                    writer.WriteLine("{0, 3:c} {1, 4:d}   |{2, 3:c}  {3, 4:d}", ch, letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
                }
            }
        }
        /// <summary>
        /// Inputs from the given data file and counts repetition of letters.
        /// </summary>
        /// <param name="CFd">Name of data file</param>
        /// <param name="letters">Object having letters and their repetitions</param>
        public static void Repetitions(string CFd, LettersFrequency letters)
        {
            using (StreamReader reader = new StreamReader(CFd))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    letters.line = line;
                    letters.Count();
                }
            }
        }
    }
}

