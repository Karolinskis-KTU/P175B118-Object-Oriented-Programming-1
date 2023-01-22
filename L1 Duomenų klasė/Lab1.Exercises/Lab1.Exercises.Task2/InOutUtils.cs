using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Lab1.Exercises.Task2
{
    class InOutUtils
    {
        /// <summary>
        /// Reading Refrigerator data from csv file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Refrigerator> ReadRefrigerators(string fileName)
        {
            List<Refrigerator> Refrigerators = new List<Refrigerator>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string manufacturer = Values[0];
                string model = Values[1];
                int capacity = int.Parse(Values[2]);
                string energyClass = Values[3];
                string mounting = Values[4];
                string colour = Values[5];
                bool freezer = bool.Parse(Values[6]);
                int price = int.Parse(Values[7]);
                int height = int.Parse(Values[8]);
                int width = int.Parse(Values[9]);
                int depth = int.Parse(Values[10]);

                Refrigerator refrigerator = new Refrigerator(manufacturer, model, capacity, energyClass, mounting, colour, freezer, price, height, width, depth);
                Refrigerators.Add(refrigerator);
            }
            return Refrigerators;
        }
        /// <summary>
        /// Convert Freezer bool to string for user readability
        /// </summary>
        /// <param name="Refrigerators"></param>
        /// <param name="index">Index for refrigerator list</param>
        /// <returns></returns>
        public static string FreezerBoolToString(List<Refrigerator> Refrigerators, int index)
        {
            string freezer = "";
            if (Refrigerators[index].Freezer == true)
            {
                freezer = "turi šaldiklį";
            } else
            {
                freezer = "neturi šaldiklio";
            }

            return freezer;
        }
        public static void PrintRefrigerators(List<Refrigerator> Refrigerators)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,10} | {1,-15} | {2,-5} | {3,-5} |", "Gamintojas", "Modelis", "Talpa", "Kaina");
            Console.WriteLine(new string('-', 74));
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                Console.WriteLine("| {0,10} | {1,-15} | {2,-5} | {3,-5} |", refrigerator.Manufacturer, refrigerator.Model, refrigerator.Capacity, refrigerator.Price);
            }
            Console.WriteLine(new string('-', 74));
        }
        /// <summary>
        /// Print refrigerator data to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type</param>
        /// <param name="Refrigerators"></param>
        public static void PrintRefrigeratorsToCSVFile(string fileName, List<Refrigerator> Refrigerators)
        {
            string[] lines = new string[Refrigerators.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldiklis", "Kaina", "Aukštis", "Plotis", "Gylis");
            for (int i = 0; i < Refrigerators.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", Refrigerators[i].Manufacturer, Refrigerators[i].Model, Refrigerators[i].Capacity, Refrigerators[i].EnergyClass, Refrigerators[i].Mounting, Refrigerators[i].Colour, FreezerBoolToString(Refrigerators, i), Refrigerators[i].Price, Refrigerators[i].Height, Refrigerators[i].Width, Refrigerators[i].Depth);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Print refrigerator data to txt file
        /// </summary>
        /// <param name="fileName">File name, with file type</param>
        /// <param name="Refrigerators"></param>
        public static void PrintRefrigeratorsToTxtFile (string fileName, List<Refrigerator> Refrigerators)
        {
            string[] lines = new string[Refrigerators.Count + 4];
            lines[0] = String.Format(new string('-', 180));
            lines[1] = String.Format("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", "Manufacturer", "Model", "Capacity", "Energy Class", "Mounting", "Colour", "Freezer", "Price", "Height", "Width", "Depth");
            lines[2] = String.Format(new string('-', 180));
            for (int i = 0; i < Refrigerators.Count; i++)
            {
                lines[i + 3] = String.Format("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", Refrigerators[i].Manufacturer, Refrigerators[i].Model, Refrigerators[i].Capacity, Refrigerators[i].EnergyClass, Refrigerators[i].Mounting, Refrigerators[i].Colour, Refrigerators[i].Freezer, Refrigerators[i].Price, Refrigerators[i].Height, Refrigerators[i].Width, Refrigerators[i].Depth);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
