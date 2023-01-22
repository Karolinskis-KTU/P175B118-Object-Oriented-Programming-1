using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Register
{
    enum Gender
    {
        Male = 1,
        Female = 2,
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            Console.WriteLine("Registro informacija:");
            InOutUtils.PrintDogs(allDogs);

            Console.WriteLine("Is viso sunu: {0}", allDogs.Count);
            Console.WriteLine("Patinu: {0}", TaskUtils.CountByGender(allDogs, Gender.Male));
            Console.WriteLine("Pateliu: {0}", TaskUtils.CountByGender(allDogs, Gender.Female));
            Console.WriteLine();

            Dog oldest = TaskUtils.FindOldestDog(allDogs);
            Console.WriteLine("Seniausias suo");
            Console.WriteLine("Vardas: {0}, Veisle: {1}, Amzius: {2}", oldest.Name, oldest.Breed, oldest.CalculateAge());
            Console.WriteLine();

            List<string> Breeds = TaskUtils.FindBreeds(allDogs);
            Console.WriteLine("Sunu veisles:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();

            Console.WriteLine("Kokios veisles sunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> FilteredByBreed = TaskUtils.FilterByBreed(allDogs, selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
