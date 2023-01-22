using System;
using System.Collections.Generic;

using System.IO; //For checking if the needed files exist

namespace Lab2.Exercises.Task2
{
    class Program
    {
        static void Main()
        {
            //File names
            const string fileRead1 = "FirstStore1.csv";
            const string fileDump1 = "FirstStoreData.txt";

            const string fileRead2 = "SecondStore1.csv";
            const string fileDump2 = "SecondStoreData.txt";

            const string onlyThere = "TikTen.csv";          // Task 3

            //Read first store data file
            if (File.Exists(fileRead1))
            {
                Store firstStore = InOutUtils.ReadRefrigerators(fileRead1);
                InOutUtils.PrintStoreToTxtFile(fileDump1, firstStore);   // Write collected data to txt file
                if (File.Exists(fileRead2))
                {
                    //Read second store data file
                    Store secondStore = InOutUtils.ReadRefrigerators(fileRead2);
                    InOutUtils.PrintStoreToTxtFile(fileDump2, secondStore); // Write collected data to txt file

                    // TASK 1
                    // Find refrigerators with highest price
                    Console.WriteLine("Brangiausi saldytuvai abejose parduotuvese:\n");
                    // If both stores have the same price
                    if (TaskUtils.FindHighestPrice(firstStore) == TaskUtils.FindHighestPrice(secondStore))
                    {
                        Store store1FilteredByPrice = TaskUtils.FindWithSamePrice(firstStore, TaskUtils.FindHighestPrice(firstStore));
                        Store store2FilteredByPrice = TaskUtils.FindWithSamePrice(secondStore, TaskUtils.FindHighestPrice(secondStore));
                        InOutUtils.PrintRefrigerators(store1FilteredByPrice);
                        InOutUtils.PrintRefrigerators(store2FilteredByPrice);
                    }
                    // If first store has a higher price
                    else if (TaskUtils.FindHighestPrice(firstStore) > TaskUtils.FindHighestPrice(secondStore))
                    {
                        Store store1FilteredByPrice = TaskUtils.FindWithSamePrice(firstStore, TaskUtils.FindHighestPrice(firstStore));
                        InOutUtils.PrintRefrigerators(store1FilteredByPrice);
                    }
                    // If second store has a higher price
                    else
                    {
                        Store store2FilteredByPrice = TaskUtils.FindWithSamePrice(secondStore, TaskUtils.FindHighestPrice(secondStore));
                        InOutUtils.PrintRefrigerators(store2FilteredByPrice);
                    }

                    // TASK 2
                    // Write manufacturers name that has the priciest product in a certain store
                    Console.WriteLine(); // For new line
                    Console.WriteLine("Gamintojas, kurio produktai yra brangiausi {0} parduotuvėje: {1}", firstStore.StoreName, TaskUtils.FindHighestPriceManufacturer(firstStore));
                    Console.WriteLine("Gamintojas, kurio produktai yra brangiausi {0} parduotuvėje: {1}", secondStore.StoreName, TaskUtils.FindHighestPriceManufacturer(secondStore));

                    //TASK 3
                    // Print items that are only in one store to csv file
                    InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(firstStore, secondStore));
                    InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(secondStore, firstStore), true); // Append second store data to same file
                }
                else
                {
                    Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", fileRead2);
                }
            }
            else
            {
                Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", fileRead1);
            }
            Console.ReadKey(); // Pause program
        }
    }
}
