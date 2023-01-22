using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Exercises.Task9
{
    internal class WordFrequency
    {
        /// <summary>
        /// Name of word
        /// </summary>
        public string Word { get; set; }
        /// <summary>
        /// Word frequency ammount
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Constructor to access data
        /// </summary>
        /// <param name="word">Name of the word</param>
        /// <param name="frequency">Word frequency ammount</param>
        public WordFrequency(string word, int frequency)
        {
            this.Word = word;
            this.Frequency = frequency;
        }

        /// <summary>
        /// Comapre to <paramref name="other"/> WordFrequency by their frequency
        /// </summary>
        /// <param name="other">WordFrequency to compare</param>
        /// <returns>Which word frequency is higher</returns>
        public int CompareTo(WordFrequency other)
        {
            return other.Frequency.CompareTo(this.Frequency);
        }
    }
}
