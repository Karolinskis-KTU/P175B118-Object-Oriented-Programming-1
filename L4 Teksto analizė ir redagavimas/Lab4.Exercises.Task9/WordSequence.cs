using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Exercises.Task9
{
    internal class WordSequence
    {
        /// <summary>
        /// Sequence starting word
        /// </summary>
        public string StartWord { get; set; }
        /// <summary>
        /// Sequence starting line
        /// </summary>
        public int StartLine { get; set; }
        /// <summary>
        /// Sequence starting word index in line
        /// </summary>
        public int StartCol { get; set; }
        /// <summary>
        /// Sequence ending word
        /// </summary>
        public string EndWord { get; set; }
        /// <summary>
        /// Sequence ending word line
        /// </summary>
        public int EndLine { get; set; }
        /// <summary>
        /// Sequence ending word index in line
        /// </summary>
        public int EndCol { get; set; }
        /// <summary>
        /// Ammount of words in sequence
        /// </summary>
        public int Ammount { get; set; }

        /// <summary>
        /// Constructor to access data
        /// </summary>
        /// <param name="startWord">Sequence starting word</param>
        /// <param name="startLine">Sequence starting line</param>
        /// <param name="startCol">Sequence starting word index in line</param>
        /// <param name="endWord">Sequence ending word</param>
        /// <param name="endLine">Sequence ending word line</param>
        /// <param name="endCol">Sequence ending word index in line</param>
        /// <param name="length">Ammount of words in sequence</param>
        public WordSequence(string startWord, int startLine, int startCol, string endWord, int endLine, int endCol, int ammount) 
        { 
            this.StartWord = startWord;
            this.StartLine = startLine;
            this.StartCol = startCol;

            this.EndWord = endWord;
            this.EndLine = endLine;
            this.EndCol = endCol;

            this.Ammount = ammount;
        }
        public WordSequence()
        {
            this.StartWord = "";
            this.StartLine = -1;
            this.StartCol = -1;

            this.EndWord = "";
            this.EndLine = -1;
            this.EndCol = -1;

            this.Ammount = 0;
        }
        /// <summary>
        /// Change data in constructor
        /// </summary>
        /// <param name="sequence">Sequence data to change to</param>
        public WordSequence(WordSequence sequence)
        {
            this.StartWord = sequence.StartWord;
            this.StartLine = sequence.StartLine;
            this.StartCol = sequence.StartCol;


            this.EndWord = sequence.EndWord;
            this.EndLine = sequence.EndLine;
            this.EndCol = sequence.EndCol;

            this.Ammount = sequence.Ammount;
        }
    }
}
