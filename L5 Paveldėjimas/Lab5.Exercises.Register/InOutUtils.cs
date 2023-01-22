using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Lab5.Exercises.Register
{
    static class InOutUtils
    {
        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);

                Enum.TryParse(Values[5], out Gender gender); //tries to convert value to enum

                switch (type)
                {
                    case "DOG":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        animals.Add(dog);
                        break;
                    case "CAT":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        animals.Add(cat);
                        break;
                    case "GUINEAPIG":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        animals.Add(guineaPig);
                        break;
                    default:
                        break;  // unknown type
                }
            }
            return animals;
        }
        public static List<Vaccination> ReadVaccinations(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);

                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }

            return Vaccinations;
        }
        public static void PrintAnimals(string label, AnimalsContainer animals)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-70} |", label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | Papildomi duomenys", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < animals.Count; i++)
            {
                
                Animal animal = animals.Get(i);
                Console.Write("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | ", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);

                // TASK1

                switch (animal.GetType().Name)
                {
                    case "Dog":
                        Console.WriteLine("Agresyvus: {0}", (animal as Dog).Agressive);
                        break;

                    default:
                        Console.Write('\n');
                        break;
                }                          

            }
            Console.WriteLine(new string('-', 74));
        }
        public static void PrintAnimalsRegister(Register animals)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < animals.AnimalsCount(); i++)
            {
                Animal animal = animals.GetElementByIndex(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }
        //public static void PrintDogsToCSVFile(string fileName, List<Dog> Dogs)
        //{
        //    string[] lines = new string[Dogs.Count + 1];
        //    lines[0] = String.Format("{0};{1};{2};{3};{4}", "Reg.Nr.", "Vardas", "Veisle", "Gimimo data", "Lytis");
        //    for (int i = 0; i < Dogs.Count; i++)
        //    {
        //        lines[i + 1] = String.Format("{0};{1};{2};{3:yyyy-MM-dd};{4}", Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
        //    }
        //    File.WriteAllLines(fileName, lines, Encoding.UTF8);
        //}



    }
}