using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
    class Program
    {
        static void Main(string[] args)
        {
            AnimalsContainer AllAnimals = InOutUtils.ReadAnimals(@"Animals.csv");
            InOutUtils.PrintAnimals("Pradiniai gyvunu duomenys", AllAnimals);

            Register register = new Register(AllAnimals);

            Console.WriteLine("Agresyviu sunu kiekis: {0}", register.CountAggresiveDogs());

            // TASK 2
            AnimalsContainer AnimalsSortByName = new AnimalsContainer(AllAnimals);
            AnimalsSortByName.Sort(new AnimalsComparatorByName());

            InOutUtils.PrintAnimals("Surikiuoti gyvunu duomenys pagal varda", AnimalsSortByName);

            AnimalsContainer AnimalsSortByBirthDate = new AnimalsContainer(AllAnimals);
            AnimalsSortByBirthDate.Sort(new AnimalsComparatorByBirthDate());

            InOutUtils.PrintAnimals("Surikiuoti guvunu duomenys pagal gimimo data", AnimalsSortByBirthDate);



            Console.ReadKey();
        }
    }
}
