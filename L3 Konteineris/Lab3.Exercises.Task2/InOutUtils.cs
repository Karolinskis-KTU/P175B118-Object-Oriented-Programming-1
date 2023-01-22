using System;
using System.Text;

using System.IO; //For checking if files exist

namespace Lab3.Exercises.Task2
{
    class InOutUtils
    {
        /// <summary>
        /// Reading Refrigerator data from csv file
        /// </summary>
        /// <param name="fileName">Directory of file</param>
        /// <returns>Primary data to new array</returns>
        public static StoreRegister ReadStore(string fileName)
        {
            StoreRegister store = new StoreRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            store.Name = Lines[0];
            store.Adress = Lines[1];
            store.Phone = Lines[2];
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
        /// Prints all store data to the console
        /// </summary>
        /// <param name="store">Store container</param>
        public static void PrintStore(StoreRegister store)
        {
            Console.WriteLine("Pavadinimas: {0}, Adresas: {1}, Telefono numeris: {2}", store.Name, store.Adress, store.Phone);
            Console.WriteLine(new string('-', 169));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", "Gamintojas", "Modelis", "Talpa", "Energijos klasė", "Montavimo tipas", "Spalva", "Šaldiklis", "Kaina", "Aukštis", "Plotis", "Gylis");
            Console.WriteLine(new string('-', 169));
            for (int i = 0; i < store.Count(); i++)
            {
                Refrigerator refrigerator = store.Get(i);
                Console.WriteLine(store.Get(i).ToString());
            }
            Console.WriteLine(new string('-', 170));
        }
        /// <summary>
        /// Prints all refrigerators to the console
        /// </summary>
        /// <param name="refrigerators">Refrigerators container</param>
        public static void PrintRefrigerators(RefrigeratorContainer refrigerators)
        {
            Console.WriteLine(new string('-', 68));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,15} |", "Gamintojas", "Modelis", "Talpa", "Kaina");
            Console.WriteLine(new string('-', 68));
            for (int i = 0; i < refrigerators.Count; i++)
            {
                Refrigerator refrigerator = refrigerators.Get(i);
                Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,15} |", refrigerator.Manufacturer, refrigerator.Model, refrigerator.Capacity, refrigerator.Price);
            }
            Console.WriteLine(new string('-', 68));
        }
        /// <summary>
        /// Prints manufacturer list to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type Example: "example.csv"</param>
        /// <param name="manufacturers">Manufacturer data</param>
        public static void PrintManufacturersToCSVFile(string fileName, ManufacturerContainer manufacturers)
        {
            string[] lines = new string[manufacturers.Count + 1];
            lines[0] = String.Format("{0}", "Gamintojas");
            for (int i = 0; i < manufacturers.Count; i++)
            {
                lines[i + 1] = String.Format("{0}", manufacturers.Get(i));
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Prints store data to csv file
        /// </summary>
        /// <param name="store">Store data</param>
        public static string[] PrintStoreToCSVFile(StoreRegister store)
        {
            string[] lines = new string[store.Count()];
            if (store.Count() > 0)
            {
                for (int i = 0; i < store.Count(); i++)
                {
                    Refrigerator refrigerator = store.Get(i);
                    lines[i] = String.Format("{0};{1}", store.Name, refrigerator.Manufacturer);
                }
            }
            return lines;
        }
        /// <summary>
        /// Prints store data to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type Example: "example.csv"</param>
        /// <param name="store">Store data</param>
        public static void PrintStoreToCSVFile(string fileName, StoreRegister store)
        {
            File.WriteAllLines(fileName, PrintStoreToCSVFile(store), Encoding.UTF8);
        }
        /// <summary>
        /// Prints store data to csv file
        /// </summary>
        /// <param name="fileName">File name, with file type. Example: "example.csv"</param>
        /// <param name="store">Store data</param>
        /// <param name="append">Checks if you want to append to the selected file</param>
        public static void PrintStoreToCSVFile(string fileName, StoreRegister store, bool append)
        {
            if (append == true)
            {
                File.AppendAllLines(fileName, PrintStoreToCSVFile(store), Encoding.UTF8);
            }
            else
            {
                File.WriteAllLines(fileName, PrintStoreToCSVFile(store), Encoding.UTF8);
            }
        }
        /// <summary>
        /// Prints <paramref name="store"/> data to txt file as <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">File name, with file type. Example: "example.txt"</param>
        /// <param name="store">Store data</param>
        public static void PrintStoreToTxtFile(string fileName, StoreRegister store)
        {
            string[] lines = new string[store.Count() + 6];
            lines[0] = String.Format(new string('-', 170));
            lines[1] = String.Format("Name: {0}, Adress: {1}, Phone number: {2}", store.Name, store.Adress, store.Phone);
            lines[2] = String.Format(new string('-', 170));
            lines[3] = String.Format("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", "Manufacturer", "Model", "Capacity", "Energy Class", "Mounting", "Colour", "Freezer", "Price", "Height", "Width", "Depth");
            lines[4] = String.Format(new string('-', 170));
            for (int i = 0; i < store.Count(); i++)
            {
                lines[i + 5] = store.Get(i).ToString();
            }
            lines[store.Count() + 5] = String.Format(new string('-', 170));
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        /// <summary>
        /// Prints <paramref name="store"/> data to txt file as <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">File name, with file type. Example: "example.txt"</param>
        /// <param name="store">Store data</param>
        public static void PrintStoreToTxtFile(string fileName, StoreRegister store, bool append)
        {
            string[] lines = new string[store.Count() + 6];
            lines[0] = String.Format(new string('-', 170));
            lines[1] = String.Format("Name: {0}, Adress: {1}, Phone number: {2}", store.Name, store.Adress, store.Phone);
            lines[2] = String.Format(new string('-', 170));
            lines[3] = String.Format("| {0,-15} | {1,-15} | {2,10} | {3,-15} | {4,-20} | {5,-20} | {6,10} | {7,5} | {8,10} | {9,10} | {10,5} |", "Manufacturer", "Model", "Capacity", "Energy Class", "Mounting", "Colour", "Freezer", "Price", "Height", "Width", "Depth");
            lines[4] = String.Format(new string('-', 170));
            for (int i = 0; i < store.Count(); i++)
            {
                lines[i + 5] = store.Get(i).ToString();
            }
            lines[store.Count() + 5] = String.Format(new string('-', 170));
            if (append)
            {
                File.AppendAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
