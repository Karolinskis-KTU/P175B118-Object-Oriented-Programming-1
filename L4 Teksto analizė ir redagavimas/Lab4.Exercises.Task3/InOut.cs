using System;
using System.Collections.Generic;
using System.Text;

using System.IO; // For reading and writing files

namespace Lab4.Exercises.Task3
{
    static class InOut
    {
        /// <summary>
        /// Reads, removes comments and prints to two files.
        /// </summary>
        /// <param name="CFd">Name of data file</param>
        /// <param name="CFr">Name of result file</param>
        /// <param name="CFdInfo">Name of informative file</param>
        public static void Process(string CFd, string CFr, string CFdInfo)
        {

            string[] lines = File.ReadAllLines(CFd, Encoding.UTF8);
            using (var writerF = File.CreateText(CFr))
            {
                using (var writerI = File.CreateText(CFdInfo))
                {
                    bool longComment = false;
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string newLine = line;
                            if (RemoveComments(line, out newLine, ref longComment))
                                writerI.WriteLine(line);
                            if (newLine.Length > 0)
                                writerF.WriteLine(newLine);
                        }
                        else
                            writerF.WriteLine(line);
                    }
                }
            }
        }

        /// <summary>
        /// Removes comments and returns an indication about performed activity.
        /// </summary>
        /// <param name="line">Line having possible comments</param>
        /// <param name="newLine">Line without comments</param>
        /// <param name="longComment">True if found /*</param>
        /// <returns></returns>
        public static bool RemoveComments(string line, out string newLine, ref bool longComment)
        {
            newLine = line;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '/' && line[i + 1] == '/')
                {
                    newLine = line.Remove(i);
                    longComment = false;
                    return true;
                }
                if (longComment)
                {
                    newLine = line.Remove(i);
                    return true;
                } else
                {
                    if (line[i] == '/' && line[i + 1] == '*')
                    {
                        newLine = line.Remove(i);
                        longComment = true;
                        return true;
                    }
                    else if (line[i] == '*' && line[i + 1] == '/')
                    {
                        newLine = line.Remove(i);
                        longComment = false;
                        return true;
                    }
                }

            }
            return false;
        }
    }
}
