using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Lab4.Exercises.Task5
{
    class TaskUtils
    {
        /// <summary>
        /// Adds surname to the given name.
        /// </summary>
        /// <param name="fin">Name of data file</param>
        /// <param name="fout">Name of result file</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <param name="name">Given word to find</param>
        /// <param name="surname">Given word to add</param>
        public static void Process (string fin, string fout, string punctuation, string name, string surname)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            using (var writer = File.CreateText(fout))
            {
                foreach (string line in lines)
                {
                    StringBuilder newLine = new StringBuilder();
                    AddSurname(line, punctuation, name, surname, newLine);
                    writer.WriteLine(newLine);
                }
            }
        }
        /// <summary>
        /// Finds name in the line and constructs new line appending given surname.
        /// </summary>
        /// <param name="line">String of data</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <param name="name">word to find</param>
        /// <param name="surname">given word to add</param>
        /// <param name="newLine">string of result</param>
        public static void AddSurname (string line, string punctuation, string name, string surname, StringBuilder newLine)
        {
            string addLine = " " + line + " ";
            int init = 1;
            int ind = addLine.IndexOf(name);
            while (ind != -1)
            {
                if (punctuation.IndexOf(addLine[ind - 1]) != -1 && punctuation.IndexOf(addLine[ind + name.Length]) != -1)
                {
                    newLine.Append(addLine.Substring(init, ind + name.Length - init));

                    newLine.Append(" " + surname);
                    init = ind + name.Length;
                }
                ind = addLine.IndexOf(name, ind + 1);
            }
            newLine.Append(line.Substring(init - 1));
        }
    }
}
