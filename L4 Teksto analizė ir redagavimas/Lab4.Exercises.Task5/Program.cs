using System;

namespace Lab4.Exercises.Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            string punctuation = " .,!?:;()\t'";
            string name = "Arvydas";
            string surname = "Sabonis";
            TaskUtils.Process(CFd, CFr, punctuation, name, surname);

        }
    }
}
