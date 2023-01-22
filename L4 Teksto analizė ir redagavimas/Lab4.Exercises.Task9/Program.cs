// U4H-10
using System;

namespace Lab4.Exercises.Task9
{
    class Program
    {
        static void Main()
        {
            const string BookDataIn = "Knyga2.txt";              // Original book data
            const string BookInfo = "Rodikliai.txt";            // Book data information (most frequent shortest words, longest sentence)
            const string BookDataOut = "ManoKnyga.txt";         // Edited orginal book (edited text alignment)

            string punctuations = ",;.:!-()? ";

            TaskUtils.ProcessData(BookDataIn, BookInfo, punctuations);
            TaskUtils.WriteEditedBook(BookDataIn, BookDataOut, punctuations);

            // Open txt files
            if (true)
            {
                TaskUtils.OpenFile(BookDataIn);
                TaskUtils.OpenFile(BookInfo);
                TaskUtils.OpenFile(BookDataOut);
            }

        }
    }
}
