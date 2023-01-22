using System;

namespace Lab4.Exercises.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            int No = InOut.LongestLine(CFd);
            InOut.RemoveLine(CFd, CFr, No);
            Console.WriteLine("Ilgiausios eilutės nr. {0, 4:d}", No + 1);
        }
    }
}
