using System;
using System.Collections.Generic;

namespace Lab2.Exercises.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            FlatsRegister register = InOutUtils.ReadFlats(@"Flats.csv");

            Console.WriteLine("Visi butai:");
            InOutUtils.PrintFlatRegister(register);

            Selection SelectionData = InOutUtils.ReadSelections(@"Selections.csv");

            FlatsRegister registerFiltered = register.FilterBySelectionCriteria(SelectionData);
            Console.WriteLine("Butai pagal duotus kriterijus:");
            InOutUtils.PrintFlatRegister(registerFiltered);

            Console.ReadKey(); // Pause program
        }
    }
}
