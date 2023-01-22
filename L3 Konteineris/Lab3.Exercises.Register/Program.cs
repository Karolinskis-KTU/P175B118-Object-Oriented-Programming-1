using System;

namespace Lab3.Exercises.Register
{
    enum Gender
    {
        Male = 1,
        Female = 2,
    }
    class Program
    {
        static void Main()
        {
            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            InOutUtils.PrintDogs("Pradiniai sunu duomenys", allDogs);
            InOutUtils.PrintDogs("Sunu duomenys rikiuoti pagal veisle", allDogs);

            //TASK 1
            if (true)
            {
                Console.WriteLine("\n\n1 savarankisko testavimas");

                allDogs.Put(new Dog(999, "TESTAS1", "TESTAS1", DateTime.Parse("2020 - 02 - 20"), Gender.Male), 3);
                InOutUtils.PrintDogs("Put testas", allDogs);

                allDogs.Insert(new Dog(888, "TESTAS1", "TESTAS1", DateTime.Parse("2020 - 02 - 20"), Gender.Male), 1);
                InOutUtils.PrintDogs("Insert testas", allDogs);

                allDogs.Remove(new Dog(999, "TESTAS1", "TESTAS1", DateTime.Parse("2020 - 02 - 20"), Gender.Male));
                InOutUtils.PrintDogs("Remove testas", allDogs);

                allDogs.RemoveAt(1);
                InOutUtils.PrintDogs("RemoveAt testas", allDogs);

                Console.WriteLine("\n\n");
            }


            //TASK 2
            allDogs.Sort(); //Sort dogs by gender and age
            InOutUtils.PrintDogs("Sunu duomenys rikiuoti pagal veisle ir lyti", allDogs);

            //Step 6   
            DogsRegister register = new DogsRegister(allDogs);
            DogsContainer requiresVaccination = register.FilterByVaccination();
            InOutUtils.PrintDogs("Reikia skiepyti (Visos veislės)", requiresVaccination);

            Console.WriteLine("Pasirinkite veisle rusiavimui");
            string selectedBreed = Console.ReadLine();
            DogsContainer filteredByBreed = register.FilterByVaccination();
            InOutUtils.PrintDogs("Reikia skiepyti (" + selectedBreed + ")", requiresVaccination.Intersect(filteredByBreed));

            //TASK 3
            DogsContainer allDogsCopy = new DogsContainer(allDogs);
            InOutUtils.PrintDogs("Sunu duomenu kopija", allDogsCopy);

            Console.ReadKey(); //Pause program
        }
    }
}
