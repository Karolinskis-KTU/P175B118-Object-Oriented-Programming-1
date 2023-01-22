using System;
using System.Text;

using System.IO; //For checking if files exist

namespace Lab5.Exercises.Task5
{
    class InOutUtils
    {
        /// <summary>
        /// Reading Refrigerator data from csv file
        /// </summary>
        /// <param name="fileName">Directory of file</param>
        /// <returns>Primary data to new array</returns>
        public static Register ReadStore(string fileName)
        {
            Register store = new Register();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            store.Name = Lines[0];
            store.Adress = Lines[1];
            store.Phone = Lines[2];
            for (int i = 3; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(';');
                string type = Values[0];
                string manufacturer = Values[1];
                string model = Values[2];
                string energyClass = Values[3];
                string colour = Values[4];
                int price = int.Parse(Values[5]);

                switch (type)
                {
                    case "FRIDGE":
                        int capacity = int.Parse(Values[6]);
                        string mounting = Values[7];
                        Enum.TryParse(Values[8], out Freezer freezer);
                        int height = int.Parse(Values[9]);
                        int width = int.Parse(Values[10]);
                        int depth = int.Parse(Values[11]);

                        Fridge fridge = new Fridge(manufacturer, model, energyClass, colour, price, capacity, mounting, freezer, height, width, depth);
                        store.Add(fridge);

                        break;
                    case "OVEN":
                        int ovenPower = int.Parse(Values[6]);
                        int programCount = int.Parse(Values[7]);

                        Oven oven = new Oven(manufacturer, model, energyClass, colour, price, ovenPower, programCount);
                        store.Add(oven);

                        break;
                   case "KETTLE":
                        int kettlePower = int.Parse(Values[6]);
                        int volume = int.Parse(Values[7]);

                        Kettle kettle = new Kettle(manufacturer, model, energyClass, colour, price, kettlePower, volume);
                        store.Add(kettle);

                        break;
                    default:
                        break; // Unkown type
                }

            }
            return store;
        }
        /// <summary>
        /// Prints all store data to console
        /// </summary>
        /// <param name="store"><paramref name="store"/> data to print</param>
        public static void PrintStore(Register store)
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";
            string dashes = new string('-', 228);
            Console.WriteLine("\nPavadinimas: {0}, Adresas: {1}, Telefono numeris: {2}", store.Name, store.Adress, store.Phone);
            Console.WriteLine(dashes);
            Console.WriteLine(spacing, "Produktas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Šaldiklis?", "Aukštis", "Plotis", "Gylis", "Galingumas", "Programų skaičius");
            Console.WriteLine(dashes);

            for (int i = 0; i < store.Count(); i++)
            {
                Device device = store.Get(i);

                switch (device.GetType().Name)
                {
                    case "Fridge":
                        Fridge fridge = device as Fridge;

                        Console.WriteLine(fridge.ToString());
                        break;

                    case "Oven":
                        Oven oven = device as Oven;

                        Console.WriteLine(oven.ToString());

                        break;
                    case "Kettle":
                        Kettle kettle = device as Kettle;

                        Console.WriteLine(kettle.ToString());

                        break;
                    default:    // Type not found
                        break;
                }
            }
            Console.WriteLine(dashes);
        }
        /// <summary>
        /// Writes all store data to txt file
        /// </summary>
        /// <param name="fileName">file to wrrite to</param>
        /// <param name="store"><paramref name="store"/> data to write</param>
        public static void WriteStoreToTxtFile(string fileName, Register store)
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";
            string dashes = new string('-', 228);

            using (StreamWriter writer = File.AppendText(fileName))
            {
                writer.WriteLine("\nPavadinimas: {0}, Adresas: {1}, Telefono numeris: {2}", store.Name, store.Adress, store.Phone);
                writer.WriteLine(dashes);
                writer.WriteLine(spacing, "Produktas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Šaldiklis?", "Aukštis", "Plotis", "Gylis", "Galingumas", "Programų skaičius");
                writer.WriteLine(dashes);

                for (int i = 0; i < store.Count(); i++)
                {
                    Device device = store.Get(i);

                    switch (device.GetType().Name)
                    {
                        case "Fridge":
                            Fridge fridge = device as Fridge;

                            writer.WriteLine(fridge.ToString());
                            break;

                        case "Oven":
                            Oven oven = device as Oven;

                            writer.WriteLine(oven.ToString());

                            break;
                        case "Kettle":
                            Kettle kettle = device as Kettle;

                            writer.WriteLine(kettle.ToString());

                            break;
                        default:    // Type not found
                            break;
                    }
                }
                writer.WriteLine(dashes);
            }
        }
        /// <summary>
        /// Writes all store manufacturers to csv file
        /// </summary>
        /// <param name="fileName">File to write to</param>
        /// <param name="store"><paramref name="store"/> to write from</param>
        public static void PrintStoreToCSVFile(string fileName, Register store)
        {
            using (StreamWriter writer = File.AppendText(fileName))
            {
                string[] lines = new string[store.Count()];
                if (store.Count() > 0)
                {
                    for (int i = 0; i < store.Count(); i++)
                    {
                        Device device = store.Get(i);
                        writer.WriteLine("{0};{1}", store.Name, device.Manufacturer);
                    }
                }
            }
        }
        /// <summary>
        /// Writes all device data to csv file
        /// </summary>
        /// <param name="fileName">File to write to</param>
        /// <param name="devices"><paramref name="devices"/> to write</param>
        public static void WriteDevices(string fileName, DeviceContainer devices)
        {
            using (StreamWriter writer = File.CreateText(fileName))
            {
                string spacing = "{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11};{12};{13}";
                writer.WriteLine(spacing, "Produktas", "Gamintojas", "Modelis", "Energijos klasė", "Spalva", "Kaina", "Talpa", "Montavimo tipas", "Šaldiklis?", "Aukštis", "Plotis", "Gylis", "Galingumas", "Programų skaičius");

                for (int i = 0; i < devices.Count; i++)
                {
                    Device device = devices.Get(i);
                    switch (device.GetType().Name)
                    {
                        case "Fridge":
                            Fridge fridge = device as Fridge;

                            writer.WriteLine(spacing, "Šaldytuvas", fridge.Manufacturer, fridge.Model, fridge.EnergyClass, fridge.Colour, fridge.Price, fridge.Capacity, fridge.Mounting, fridge.Freezer, fridge.Height, fridge.Width, fridge.Depth, "-", "-");
                            break;

                        case "Oven":
                            Oven oven = device as Oven;

                            writer.WriteLine(spacing, "Mikrobanginė", oven.Manufacturer, oven.Model, oven.EnergyClass, oven.Colour, oven.Price, "-", "-", "-", "-", "-", "-", oven.Power, oven.ProgramCount);

                            break;
                        case "Kettle":
                            Kettle kettle = device as Kettle;

                            writer.WriteLine(spacing, "Virdulys", kettle.Manufacturer, kettle.Model, kettle.EnergyClass, kettle.Colour, kettle.Price, kettle.Volume, "-", "-", "-", "-", "-", kettle.Power, "-");

                            break;
                        default:    // Type not found
                            break;
                    }
                }
            }
            
        }
        /// <summary>
        /// Prints all <paramref name="refrigerators"/> to console
        /// </summary>
        /// <param name="refrigerators"><paramref name="refrigerators"/> to write</param>
        public static void PrintRefrigerators(DeviceContainer refrigerators)
        {
            Console.WriteLine(new string('-', 68));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,15} |", "Gamintojas", "Modelis", "Talpa", "Kaina");
            Console.WriteLine(new string('-', 68));
            for (int i = 0; i < refrigerators.Count; i++)
            {
                Fridge refrigerator = refrigerators.Get(i) as Fridge;
                Console.WriteLine("| {0,-15} | {1,-15} | {2,10} | {3,15} |", refrigerator.Manufacturer, refrigerator.Model, refrigerator.Capacity, refrigerator.Price);
            }
            Console.WriteLine(new string('-', 68));
        }
        /// <summary>
        /// Prints store's devices count
        /// </summary>
        /// <param name="store"><paramref name="store"/> to write from</param>
        /// <param name="deviceCount">Ammounts of all devices</param>
        public static void PrintManufacturerStatistics(Register store, int[] deviceCount)
        {
            Console.WriteLine("Pavadinimas: {0}, Adresas: {1}, Telefono numeris: {2}", store.Name, store.Adress, store.Phone);
            DeviceContainer deviceContainer = new DeviceContainer();
            deviceContainer.Add(store);
            DeviceRegister deviceRegister = new DeviceRegister(deviceContainer);

            Console.WriteLine("Šaldytuvai: {0}", deviceCount[0]);
            Console.WriteLine("Mikrobangų krosnelės : {0}", deviceCount[1]);
            Console.WriteLine("Virduliai: {0} \n", deviceCount[2]);


        }

    }
}