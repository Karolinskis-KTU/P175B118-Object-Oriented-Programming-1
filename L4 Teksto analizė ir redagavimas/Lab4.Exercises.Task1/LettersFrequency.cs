using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Exercises.Task1
{
    class LettersFrequency
    {
        private const int CMax = 256;
        public int[] Frequency;        // Frequency of letters
        public string line { get; set; }
        public LettersFrequency()
        {
            line = "";
            Frequency = new int[CMax];
            for (int i = 0; i < CMax; i++)
            {
                Frequency[i] = 0;
            }
        }
        public int Get(char character)
        {
            return Frequency[character];
        }
        public void Count()
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (('a' <= line[i] && line[i] <= 'z' || 'A' <= line[i] && line[i] <= 'Z'))
                {
                    Frequency[line[i]]++;
                }
            }
        }
        public char MostFrequent()
        {
            char letter = (char)0;
            int frequency = 0;
            for (int i = 0; i < CMax; i++)
            {
                if (Frequency[i] > frequency)
                {
                    letter = (char)i;
                }
            }
            return letter;
        }
    }
}
