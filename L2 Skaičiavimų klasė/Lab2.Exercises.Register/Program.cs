using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Register
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
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");

            Console.WriteLine("\nSarašas šunų:");
            InOutUtils.PrintDogsRegister(register);

            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinu: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Pateliu: {0}", register.CountByGender(Gender.Female));

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccinations(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);

            Console.WriteLine("\nSarašas šunų, kuriu vakcinos galiojimo laikas pasibaigė:");
            InOutUtils.PrintDogsRegister(register.FilterByVaccinationExpired());

            Console.ReadKey(); //Pause program


        }
    }
}
