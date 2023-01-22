using System;



namespace Lab4.Exercises.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";

            //char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            //Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd, punctuation));

            string punctuation = "[\\s,.;:!?()\\-]+";
            Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd, punctuation));

        }
    }
}
