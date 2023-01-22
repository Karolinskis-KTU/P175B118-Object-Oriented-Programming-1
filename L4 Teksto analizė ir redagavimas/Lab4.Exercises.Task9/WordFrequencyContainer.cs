using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Exercises.Task9
{
    class WordFrequencyContainer
    {
        private WordFrequency[] wordFrequencies;
        private int Capacity = 10;
        /// <summary>
        /// Ammount of elements in container
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Creates new WordFrequency container array for container
        /// </summary>
        /// <param name="capacity"></param>
        public WordFrequencyContainer(int capacity = 10)
        {
            this.wordFrequencies = new WordFrequency[capacity];
        }

        /// <summary>
        /// Gets a certain word with frequency from container
        /// </summary>
        /// <param name="index">Index to get from</param>
        /// <returns>Returns a certain word with frequency from container</returns>
        public WordFrequency Get(int index)
        {
            return this.wordFrequencies[index];
        }

        /// <summary>
        /// Checks if the given word exists in container
        /// </summary>
        /// <param name="word">Word to check for</param>
        /// <param name="index">Index of the word if found</param>
        /// <returns>Returns true if <paramref name="word"/> exists in container</returns>
        public bool WordExists(string word, out int index)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (wordFrequencies[i].Word == word)
                {
                    index = i;
                    return true;
                }
            }
            index = -1;
            return false;
        }

        /// <summary>
        /// Add a word to container
        /// </summary>
        /// <param name="word">Word to add</param>
        public void Add(WordFrequency word)
        {
            // Check if word is longer than 3 chraracters
            if (word.Word.Length >= 3)
            {
                int index;
                if (WordExists(word.Word, out index) == true)   // Word exists => increment frequency
                {
                    this.wordFrequencies[index].Frequency++;
                }
                else 
                {
                    if (this.Count == this.Capacity)    // Container is full
                    {
                        //Get longest word in container
                        string longestWord = "";
                        
                        for (int i = 0; i < this.Count; i++)
                        {
                            if (longestWord.Length < this.wordFrequencies[i].Word.Length)
                            {
                                longestWord = this.wordFrequencies[i].Word;
                            }
                        }

                        // Check if given word is shorter than longest word => replace with new word
                        if (longestWord.Length > word.Word.Length)
                        {
                            Replace(new WordFrequency(longestWord, 0), word);
                            
                        }
                    }
                    else
                    {
                        this.wordFrequencies[this.Count++] = word;
                    }
                }


                for (int i = 0; i < this.Count; i++)
                {
                    WordFrequency words = wordFrequencies[i];
                }
            }
        }
        /// <summary>
        /// Replaces <paramref name="word1"/> with <paramref name="word2"/>
        /// </summary>
        /// <param name="word1">Word to replace</param>
        /// <param name="word2">Word to replace with</param>
        public void Replace(WordFrequency word1, WordFrequency word2)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (word1.Word == this.wordFrequencies[i].Word)
                {
                    this.wordFrequencies[i] = word2;
                    break;
                }
            }
        }
        /// <summary>
        /// Gets the longest word in container
        /// </summary>
        /// <returns>Returns the longest word in container</returns>
        private WordFrequency GetLongestWord()
        {
            WordFrequency longestWord = new WordFrequency("",0);
            for (int i = 0; i < this.Count; i++)
            {
                if (longestWord.Word.Length < this.wordFrequencies[i].Word.Length)
                {
                    longestWord = this.wordFrequencies[i];
                }
            }
            return longestWord;
        }

        /// <summary>
        /// Sorts the container by frequency
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1 ;i++)
                {
                    WordFrequency a = this.wordFrequencies[i];
                    WordFrequency b = this.wordFrequencies[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.wordFrequencies[i] = b;
                        this.wordFrequencies[i +1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
