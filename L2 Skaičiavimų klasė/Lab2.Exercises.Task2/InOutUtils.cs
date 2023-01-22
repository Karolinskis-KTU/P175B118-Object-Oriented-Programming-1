using System;
using System.Collections.Generic;
using System.Text;

using System.IO; //For checking if files exist

namespace Lab2.Exercises.Task2
{
    class InOutUtils
    {
        /// <summary>
        /// Reading Refrigerator data from csv file
        /// </summary>
        /// <param name="fileName">Directory of file</param>
        /// <returns>Primary data to new array</returns>
        public static Store ReadRefrigerators(string fileName)
        {
            Store store = new Store();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            store.StoreName = Lines[0];
            store.StoreAdress = Lines[1];
            store.StorePhone = Lines[2];
            for (int i = 3; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(';');
                string manufacturer = Values[0];
                string model = Values[1];
                int capacity = int.Parse(Values[2]);
                string energyClass = Values[3];
                string mounting = Values[4];
                string colour = Values[5];
                Enum.TryParse(Values[6], out Freezer freezer);
                int price = int.Parse(Values[7]);
                int height = int.Parse(Values[8]);
                int width = int.Parse(Values[9]);
                int depth = int.Parse(Values[10]);

                Refrigerator refrigerator = new Refrigerator(manufacturer, model, capacity, energyClass, mounting, colour, freezer, price, height, width, depth);
                store.Add(refrigerator);
            }
            return store;
        }
        /// <summary>
        /// Prints all refrigerators to the console
        /// </summary>
        /// <param name="Refrigerators">Array of refridgerators</param>
        public static void PrintRefrigerators(Store store)
        {
            Console.WriteLine("Pavadinimas: {0}, Adresas: {1}, Telefono numeris: {2}", store.StoreName, store.StoreAdress, store.StorePhone);
            Console.WriteLine(new string('-', 169));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldiklis", "Kaina", "Aukštis", "Plotis", "Gylis");
            Console.WriteLine(new string('-', 169));
            for (int i = 0; i < store.CountRefrigerators(); i++)
            {
                Refrigerator refrigerator = store.GetElement(i);
                Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,-10} | {7,5} | {8,10} | {9,10} | {10,5} |", refrigerator.Manufacturer, refrigerator.Model, refrigerator.Capacity, refrigerator.EnergyClass, refrigerator.Mounting, refrigerator.Colour, refrigerator.Freezer, refrigerator.Price, refrigerator.Height, refrigerator.Width, refrigerator.Depth);
            }
            Console.WriteLine(new string('-', 170));
        }
        /// <summary>
        /// Print refrigerator data to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type</param>
        /// <param name="Refrigerators">Array of refrigerators</param>
        public static void PrintRefrigeratorsToCSVFile(string fileName, List<Refrigerator> Refrigerators)
        {
            string[] lines = new string[Refrigerators.Count + 1];
            lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldiklis", "Kaina", "Aukštis", "Plotis", "Gylis");
            for (int i = 0; i < Refrigerators.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10}", Refrigerators[i].Manufacturer, Refrigerators[i].Model, Refrigerators[i].Capacity, Refrigerators[i].EnergyClass, Refrigerators[i].Mounting, Refrigerators[i].Colour, Refrigerators[i].Freezer, Refrigerators[i].Price, Refrigerators[i].Height, Refrigerators[i].Width, Refrigerators[i].Depth);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Prints store data to csv file
        /// </summary>
        /// <param name="store">Store data</param>
        public static string[] PrintStoreToCSVFile(Store store)
        {
            string[] lines = new string[store.CountRefrigerators()];
            if (store.CountRefrigerators() > 0)
            {

            
                for (int i = 0; i < store.CountRefrigerators(); i++)
                {
                    Refrigerator refrigerator = store.GetElement(i);
                    lines[i] = String.Format("{0};{1}", store.StoreName, refrigerator.Manufacturer);
                }
            }
            return lines;
        }
        /// <summary>
        /// Prints store data to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type Example: "example.csv"</param>
        /// <param name="store">Store data</param>
        public static void PrintStoreToCSVFile(string fileName, Store store)
        {
            File.WriteAllLines(fileName, PrintStoreToCSVFile(store), Encoding.UTF8);
        }
        /// <summary>
        /// Prints store data to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type. Example: "example.csv"</param>
        /// <param name="store">Store data</param>
        /// <param name="append">Checks if you want to append to the selected file</param>
        public static void PrintStoreToCSVFile(string fileName, Store store, bool append)
        {
            if (append == true)
            {
                File.AppendAllLines(fileName, PrintStoreToCSVFile(store), Encoding.UTF8);
            } else
            {
                File.WriteAllLines(fileName, PrintStoreToCSVFile(store), Encoding.UTF8);
            }  
        }
        /// <summary>
        /// Prints <paramref name="store"/> data to txt file as <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">File name, with file type. Example: "example.txt"</param>
        /// <param name="store">Store data</param>
        public static void PrintStoreToTxtFile (string fileName, Store store)
        {
            string[] lines = new string[store.CountRefrigerators() + 6];
            lines[0] = String.Format(new string('-', 170));
            lines[1] = String.Format("Name: {0}, Adress: {1}, Phone number: {2}", store.StoreName, store.StoreAdress, store.StorePhone);
            lines[2] = String.Format(new string('-', 170));
            lines[3] = String.Format("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", "Manufacturer", "Model", "Capacity", "Energy Class", "Mounting", "Colour", "Freezer", "Price", "Height", "Width", "Depth");
            lines[4] = String.Format(new string('-', 170));
            for (int i = 0; i < store.CountRefrigerators(); i++)
            {
                Refrigerator refrigerator = store.GetElement(i);
                lines[i + 5] = String.Format("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,-10} | {7,5} | {8,10} | {9,10} | {10,5} |", refrigerator.Manufacturer, refrigerator.Model, refrigerator.Capacity, refrigerator.EnergyClass, refrigerator.Mounting, refrigerator.Colour, refrigerator.Freezer, refrigerator.Price, refrigerator.Height, refrigerator.Width, refrigerator.Depth);
            }
            lines[store.CountRefrigerators()+5] = String.Format(new string('-', 170));
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
