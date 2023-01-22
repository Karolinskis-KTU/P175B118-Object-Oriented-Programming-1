using System;

using System.IO; //For checking if the needed files exist

namespace Lab5.Exercises.Task5
{
    class Program
    {
        static void Main()
        {
            //File names
            const string StoreData1 = "Store1_2.csv";       // First Store data file
            const string StoreData2 = "Store2_2.csv";       // Second Store data file
            const string StoreData3 = "Store3_2.csv";       // Third Store data file

            const string fileDump = "StoreData.txt";        // All stores data dump file

            const string APlusDevices = "A+.csv";           // TASK 3 List of all devices that have A+ energy rating
            const string onlyThere = "TikTen.csv";          // TASK 4 Manufacturer products that are only in one store

            const bool Debug = false;                       // Opens created files

            bool FilesExist = false;


            if (File.Exists(StoreData1))
            {
                if (File.Exists(StoreData2))
                {
                    if (File.Exists(StoreData3))
                    {
                        FilesExist = true;
                    } else
                    {
                        Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", StoreData3);
                    }
                } else
                {
                    Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", StoreData2);
                }
            } else
            {
                Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", StoreData1);
            }

            if (FilesExist)
            {
                Register store1 = InOutUtils.ReadStore(StoreData1);

                Register store2 = InOutUtils.ReadStore(StoreData2);

                Register store3 = InOutUtils.ReadStore(StoreData3);

                DeviceContainer allDevices = new DeviceContainer();
                allDevices.Add(store1);
                allDevices.Add(store2);
                allDevices.Add(store3);
                allDevices.Sort(new DeviceComparatorByPrice());
                DeviceRegister allDeviceRegister = new DeviceRegister(allDevices);

                // Dump all collected data to txt file
                if (File.Exists(fileDump))
                {
                    File.Delete(fileDump);
                }
                InOutUtils.WriteStoreToTxtFile(fileDump, store1);
                InOutUtils.WriteStoreToTxtFile(fileDump, store2);
                InOutUtils.WriteStoreToTxtFile(fileDump, store3);


                // TASK 1
                // Calculate "Siemens" products
                // Print to console
                string manufacturer = "Siemens";

                Console.WriteLine("{0} šaldytuvų, mikrobangų krosnelių ir virdulių parduotuvėse:", manufacturer);
                
                DeviceContainer store1Devices = new DeviceContainer();
                store1Devices.Add(store1);
                DeviceRegister store1Register = new DeviceRegister(store1Devices);
                InOutUtils.PrintManufacturerStatistics(store1, store1Register.CountManufacturerDevice(manufacturer));

                DeviceContainer store2Devices = new DeviceContainer();
                store2Devices.Add(store2);
                DeviceRegister store2Register = new DeviceRegister(store2Devices);
                InOutUtils.PrintManufacturerStatistics(store2, store2Register.CountManufacturerDevice(manufacturer));

                DeviceContainer store3Devices = new DeviceContainer();
                store3Devices.Add(store3);
                DeviceRegister store3Register = new DeviceRegister(store3Devices);
                InOutUtils.PrintManufacturerStatistics(store3, store3Register.CountManufacturerDevice(manufacturer));


                // TASK 2
                // Create a list of top 10 most popular refrigerators
                // Print to console
                DeviceContainer allDevicesFiltered = allDeviceRegister.GetTopRefrigerators(10);

                Console.WriteLine("\nTop 10 pigiausiu saldytuvu:");
                InOutUtils.PrintRefrigerators(allDevicesFiltered);



                // TASK 3
                // Create a list of all products with a A+ rating
                // Writes the list to AplusDevices csv file
                string rating = "A+";
                DeviceContainer aPlusDeviceContainer = new DeviceContainer();
                aPlusDeviceContainer = allDeviceRegister.GetDevicesWithRating(rating);

                InOutUtils.WriteDevices(APlusDevices, aPlusDeviceContainer);

                

                // TASK 4
                // Print all products that are available only in one store
                if (File.Exists(onlyThere))
                {
                    File.Delete(onlyThere);
                }

                InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(store1, store2, store3));
                InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(store2, store1, store3));
                InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(store3, store1, store2));

                

                if (Debug)
                {
                    System.Diagnostics.Process.Start("notepad.exe", fileDump);
                    System.Diagnostics.Process.Start("notepad.exe", APlusDevices);  // Opens A+ devices file
                    System.Diagnostics.Process.Start("notepad.exe", onlyThere);
                }

            }
            Console.ReadKey();
        }
    }
}
