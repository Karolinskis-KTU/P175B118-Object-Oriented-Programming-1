using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;

namespace Lab4.Exercises.Task9
{
    static class TaskUtils
    {
        /// <summary>
        /// Process data from file by first section rules
        /// </summary>
        /// <param name="fileIn">File to read from</param>
        /// <param name="fileOut">File to write to</param>
        /// <param name="punctuations">Punctuations to split words</param>
        public static void ProcessData(string fileIn, string fileOut, string punctuations)
        {
            string dashes = new string('-', 21);
            using (var writer = File.CreateText(fileOut))
            {
                // TASK 1
                WordFrequencyContainer wordFrequencyContainer = GetWordFrequencies(fileIn, punctuations);
                wordFrequencyContainer.Sort();

                writer.WriteLine(dashes);
                writer.WriteLine("Trumpiausi zodziai, kurie ne trumpesni, nei 3 simboliai");
                writer.WriteLine(dashes);
                writer.WriteLine("|{0, -10} | {1, 6}|", "Zodis", "Kiekis");
                writer.WriteLine(dashes);
                for (int y = 0; y < wordFrequencyContainer.Count; y++)
                {
                    WordFrequency word = wordFrequencyContainer.Get(y);
                    writer.WriteLine("|{0, -10} | {1, 6}|", word.Word, word.Frequency);
                }
                writer.WriteLine(dashes);

                writer.WriteLine();

                // TASK 2
                writer.WriteLine("Ilgiausias teskto fragmentas");
                writer.WriteLine(dashes+dashes);
                WordSequence wordSequence = GetSequence(fileIn, punctuations);

                int i = -1; // Line num
                writer.WriteLine("| {0,5} | {1}", "Eilutės nr.", "Eilutė");
                writer.WriteLine(dashes+dashes);

                using (StreamReader reader = new StreamReader(fileIn))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        MatchCollection matches = Regex.Matches(line, "[^" + punctuations + "]+");
                        i++;

                        if (i == wordSequence.StartLine)
                        {

                            // If start and ending is not on the same line
                            if (wordSequence.StartLine != wordSequence.EndLine)
                            {
                                Match firstMatch = matches[wordSequence.StartCol - 1];

                                writer.WriteLine("| {0,11} | {1}", i, line.Substring(firstMatch.Index));
                            }
                            //If start and ending is on the same line
                            else if(wordSequence.StartLine == wordSequence.EndLine)
                            {
                                Match firstMatch = matches[wordSequence.StartCol];
                                Match lastMatch = matches[wordSequence.EndCol];
                                int length = lastMatch.Index + lastMatch.Length - firstMatch.Index + 1;
                                writer.WriteLine("| {0,11} | {1}", i, line.Substring(firstMatch.Index, length));
                                break;
                            }

                        }
                        else if (i == wordSequence.EndLine)
                        {
                            Match lastMatch = matches[wordSequence.EndCol];

                            writer.WriteLine("| {0,11} | {1}", i, line.Substring(0, lastMatch.Index + lastMatch.Length));
                        }
                        else if (i >= wordSequence.StartLine && i <= wordSequence.EndLine)
                        {
                            writer.WriteLine("| {0,11} | {1}", i, line);
                        }

                    }
                }
                writer.WriteLine(dashes + dashes);

            }
        }

        /// <summary>
        /// Write edited book to file
        /// </summary>
        /// <param name="fileIn">File to read from</param>
        /// <param name="fileOut">File to write to</param>
        /// <param name="punctuations">Punctuations to separate words</param>
        public static void WriteEditedBook(string fileIn, string fileOut, string punctuations)
        {
            using (var writter = File.CreateText(fileOut))
            {
                int padding = 0;
                string[] words;
                using (StreamReader reader = new StreamReader(fileIn))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        words = TaskUtils.GetWords(line, punctuations.ToCharArray());
                        for (int i = 0; i < words.Length; i++)
                        {
                            padding = TaskUtils.FindWidestWords(i, fileIn, punctuations);
                            writter.Write("{0}", words[i].PadRight(padding));
                        }
                        writter.Write('\n');
                    }
                }
            }
        }

        /// <summary>
        /// Gets Top10 most frequent words in file
        /// </summary>
        /// <param name="fileIn">File to read from</param>
        /// <param name="punctuations">Punctuations to separate words</param>
        /// <returns>Returns Top10  most frequent words in file</returns>
        private static WordFrequencyContainer GetWordFrequencies(string fileIn, string punctuations)
        {
            char[] punctuation = punctuations.ToCharArray();
            WordFrequencyContainer wordFrequencyContainer = new WordFrequencyContainer();

            using (StreamReader reader = new StreamReader(fileIn))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in words)
                    {
                        WordFrequency tempWord = new WordFrequency(word, 1);
                        wordFrequencyContainer.Add(tempWord);
                    }
                }
            }
            return wordFrequencyContainer;
        }
        /// <summary>
        /// Gets the longest word sequence where first match last letter is equal to next match first letter
        /// </summary>
        /// <param name="fileIn">File to read</param>
        /// <param name="punctuations">Punctations to split words</param>
        /// <returns>Returns longest sequence data</returns>
        public static WordSequence GetSequence(string fileIn, string punctuations)
        {
            WordSequence longestSequence = new WordSequence();
            WordSequence tempLongestSequence = new WordSequence();

            using (StreamReader reader = new StreamReader(fileIn))
            {
                int i = -1;
                int j = -1;
                bool validSequence = false;

                string line;
                while((line = reader.ReadLine()) != null)
                {
                    i++;
                    j = 0;

                    MatchCollection matches = Regex.Matches(line, "[^" + punctuations + "]+");
                    foreach (Match match in matches)
                    {
                        j++;
                        Match firstMatch = match;
                        Match secondMatch = match.NextMatch();

                        if (validSequence)
                        {
                            string firstValue = firstMatch.Value;
                            string secondValue = secondMatch.Value;

                            if (j == matches.Count)
                            {
                                //Sleep
                            }
                            else if (j == 1)
                            {
                                if (tempLongestSequence.EndWord.ToLower()[tempLongestSequence.EndWord.Length - 1] == firstValue.ToLower()[0])
                                {
                                    tempLongestSequence.EndWord = firstMatch.Value;
                                    tempLongestSequence.EndLine = i;
                                    tempLongestSequence.EndCol = j;

                                    tempLongestSequence.Ammount++;
                                    if (firstValue.ToLower()[firstValue.Length - 1] == secondValue.ToLower()[0])
                                    {
                                        tempLongestSequence.EndWord = secondMatch.Value;
                                        tempLongestSequence.EndLine = i;
                                        tempLongestSequence.EndCol = j + 1;

                                        tempLongestSequence.Ammount++;
                                    } else
                                    {
                                        validSequence = false;
                                        if (tempLongestSequence.Ammount > longestSequence.Ammount)
                                        {
                                            longestSequence = new WordSequence(tempLongestSequence);
                                        }

                                        tempLongestSequence = new WordSequence();
                                    }
                                } else
                                {
                                    validSequence = false;
                                    if (tempLongestSequence.Ammount > longestSequence.Ammount)
                                    {
                                        longestSequence = new WordSequence(tempLongestSequence);
                                    }

                                    tempLongestSequence = new WordSequence();
                                }
                            } 
                            else
                            {
                                if (firstMatch.Value.ToLower()[firstMatch.Value.Length - 1] == secondValue.ToLower()[0])
                                {
                                    validSequence = true;

                                    tempLongestSequence.EndWord = secondMatch.Value;
                                    tempLongestSequence.EndLine = i;
                                    tempLongestSequence.EndCol = j;

                                    tempLongestSequence.Ammount++;
                                }
                                else
                                {
                                    validSequence = false;
                                    if (tempLongestSequence.Ammount > longestSequence.Ammount)
                                    {
                                        longestSequence = new WordSequence(tempLongestSequence);
                                    }

                                    tempLongestSequence = new WordSequence();
                                }
                            }
                        } else
                        {
                            if (j == matches.Count)
                            {
                                tempLongestSequence.StartWord = firstMatch.Value;
                                tempLongestSequence.StartLine = i;
                                tempLongestSequence.StartCol = j;

                                tempLongestSequence.EndWord = firstMatch.Value;
                                tempLongestSequence.EndLine = i;
                                tempLongestSequence.EndCol = j;

                                tempLongestSequence.Ammount = 1;
                            } else
                            {
                                if (firstMatch.Value.ToLower()[firstMatch.Value.Length - 1] == secondMatch.Value.ToLower()[0])
                                {
                                    validSequence = true;

                                    tempLongestSequence.StartWord = firstMatch.Value;
                                    tempLongestSequence.StartLine = i;
                                    tempLongestSequence.StartCol = j;

                                    tempLongestSequence.EndWord = secondMatch.Value;
                                    tempLongestSequence.EndLine = i;
                                    tempLongestSequence.EndCol = j + 1;

                                    tempLongestSequence.Ammount = 2;

                                }
                            }


                        }


                    }
                }
            }
            return longestSequence;
        }

        /// <summary>
        /// Splits words from line by punctuations and removes multiple punctuations
        /// </summary>
        /// <param name="line">Line to split from</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <returns>string array with all words in line</returns>
        public static string[] GetWords(string line, char[] punctuations)
        {
            string[] words;

            string punctuationsString = new string(punctuations);
            string pattern = "[" + punctuationsString + "]*([" + punctuationsString + "])";

            line = Regex.Replace(line, pattern, "$1 ");
            words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                bool flag = false;
                foreach (char punctuation in punctuations)
                {
                    if (words[i][words[i].Length - 1] == punctuation)
                    {
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    words[i] += @" ";
                }
            }
            return words;
        }

        /// <summary>
        /// Finds longest word length in <paramref name="pos"/> index
        /// </summary>
        /// <param name="pos">Word index in line to check</param>
        /// <param name="fileIn">File to read from</param>
        /// <param name="punctuation">Punctuation marks to separate words</param>
        /// <returns>Returns the length of the longest word</returns>
        private static int FindWidestWords(int pos, string fileIn, string punctuations)
        {
            int length = -1;
            string[] words;
            char[] punctuation = punctuations.ToCharArray();
            using (StreamReader reader = new StreamReader(fileIn))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words = TaskUtils.GetWords(line, punctuation);
                    if (pos < words.Length)
                    {
                        if (words[pos].Length > length)
                        {
                            length = words[pos].Length;
                        }
                    }
                }
            }
            return length;
        }

        /// <summary>
        /// Opens .txt file in notepad.exe
        /// </summary>
        /// <param name="file">File to open</param>
        public static void OpenFile(string file)
        {
            System.Diagnostics.Process.Start("notepad.exe", file);
        }
    }
}
