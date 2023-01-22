using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read data file
            List <Refrigerator> allRefrigerators = InOutUtils.ReadRefrigerators(@"Refrigerators3.csv");
            InOutUtils.PrintRefrigeratorsToTxtFile("data.txt", allRefrigerators);   //Write collected data to txt file

            //Find how many models are in the list from a certain manufacturer
            Console.WriteLine("Iš viso skirtingų 'Siemens' modelių yra: {0}", TaskUtils.CountManufacturerModels(allRefrigerators, "Siemens"));
            Console.WriteLine();

            //Print all cheapest models with a minimum volume of 80
            Console.WriteLine("Pigiausi pastatomi šaldytuvai, kurių talpa 80 litrų arba didesnė:");
            List<Refrigerator> FilteredByPrice = TaskUtils.FindAllWithSamePrice(allRefrigerators, TaskUtils.FindLowestPrice(allRefrigerators));
            InOutUtils.PrintRefrigerators(FilteredByPrice);

            //Write models with a volume over 80 to csv file 
            List<Refrigerator> FilteredByCapacity = TaskUtils.FilterByCapacity(allRefrigerators);
            string fileName = "Pastatomi80" + ".csv";
            InOutUtils.PrintRefrigeratorsToCSVFile(fileName, FilteredByCapacity);

            
            Console.ReadKey();
        }
    }
}
