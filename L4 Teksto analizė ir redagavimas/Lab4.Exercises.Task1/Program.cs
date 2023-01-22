using System;

namespace Lab4.Exercises.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);
            Console.WriteLine("Dažniausiai vartojama raidė: {0}", letters.MostFrequent());
            InOut.PrintRepetitions(CFr, letters);

        }
    }
}
