using System;
using System.Collections.Generic;
using System.Text;

using System.IO;    // For reading and writing to files

namespace Lab4.Exercises.Task2
{
    static class InOut
    {
        /// <summary>
        /// Finds the ordinal number of the longest line.
        /// </summary>
        /// <param name="CFr">Name of data file</param>
        /// <returns>Returns the ordinal number of the longest line</returns>
        public static int LongestLine(string CFr)
        {
            int No = -1;
            using (StreamReader reader = new StreamReader(CFr, Encoding.UTF8)) 
            {
                string line;
                int length = 0;
                int lineNo = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Length > length)
                    {
                        length = line.Length;
                        No = lineNo;
                    }
                    lineNo++;
                }
            }
            return No;
        }
        /// <summary>
        /// Removes the line of the given ordinal number.
        /// </summary>
        /// <param name="CFd">Name of data file</param>
        /// <param name="CFr">Name of result file</param>
        /// <param name="No">The ordinal number of the longest line</param>
        public static void RemoveLine(string CFd, string CFr, int No)
        {
            using (StreamReader reader = new StreamReader(CFd, Encoding.UTF8))
            {
                string longestLine = "";
                string line;
                int lineNo = 0;
                using (var writer = File.CreateText(CFr))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (No != lineNo && longestLine != line)
                        {
                            writer.WriteLine(line);
                        }
                        if (No == lineNo)
                        {
                            longestLine = line;
                        }
                        lineNo++;
                    }
                }
            }
        }

    }
}
