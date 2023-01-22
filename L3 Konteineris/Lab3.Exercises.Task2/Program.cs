using System;

using System.IO; //For checking if the needed files exist

namespace Lab3.Exercises.Task2
{
    class Program
    {
        static void Main()
        {
            //File names
            const string fileRead1 = "FirstStore.csv";      // First Store data file
            const string fileRead2 = "SecondStore.csv";     // Second Store data file

            const string fileDump = "StoreData.txt";        // Store data dump file

            const string manufacturers = "Gamintojai.csv";  // TASK 3 All product manufacturer names
            const string onlyThere = "TikTen.csv";          // TASK 4 Manufacturer products that are only in one store


            if (File.Exists(fileRead1))
            {
                StoreRegister firstStore = InOutUtils.ReadStore(fileRead1);
                InOutUtils.PrintStoreToTxtFile(fileDump, firstStore);
                if (File.Exists(fileRead2))
                {
                    StoreRegister secondStore = InOutUtils.ReadStore(fileRead2);
                    InOutUtils.PrintStoreToTxtFile(fileDump, secondStore, true);

                    // --------------------------------------------------------------------------
                    // TASK 1
                    // Raskite brangiausią šaldytuvą, kurio talpa 80 litrų ar didesnė.
                    // Atspausdinkite ekrane visus jo duomenis. Jei yra keli, spausdinkite visus.
                    // --------------------------------------------------------------------------
                    StoreRegister firstStoreRegister = new StoreRegister(firstStore);
                    StoreRegister secondStoreRegister = new StoreRegister(secondStore);

                    // Find Refrigerators with highest price
                    Console.WriteLine("Brangiausi saldytuvai abejose parduotuvese:\n");
                    // Both stores have the same price
                    if (firstStoreRegister.FindHighestPrice() == secondStoreRegister.FindHighestPrice())
                    {
                        StoreRegister firstStoreFiltered = firstStoreRegister.FindWithSamePrice(firstStoreRegister.FindHighestPrice());
                        InOutUtils.PrintStore(firstStoreFiltered);

                        StoreRegister secondStoreFiltered = secondStoreRegister.FindWithSamePrice(secondStoreRegister.FindHighestPrice());
                        InOutUtils.PrintStore(secondStoreFiltered);
                    }
                    // First store has higher price
                    else if (firstStoreRegister.FindHighestPrice() > secondStoreRegister.FindHighestPrice())
                    {
                        StoreRegister firstStoreFiltered = firstStoreRegister.FindWithSamePrice(firstStoreRegister.FindHighestPrice());
                        InOutUtils.PrintStore(firstStoreFiltered);
                    }
                    // Second store has higher price
                    else if (firstStoreRegister.FindHighestPrice() < secondStoreRegister.FindHighestPrice())
                    {
                        StoreRegister secondStoreFiltered = secondStoreRegister.FindWithSamePrice(secondStoreRegister.FindHighestPrice());
                        InOutUtils.PrintStore(secondStoreFiltered);
                    }

                    // ---------------------------------------------------------------------------------------------------------------------
                    // TASK 2
                    // Sudarykite dešimties pigiausių pastatomų šaldytuvų, kurių talpa 80 litrų ar didesnė, sąrašą.
                    // Jei skirtingose parduotuvėse esančių šaldytuvų gamintojas ir modelis sutampa – į sąrašą jį įtraukite tik vieną kartą.
                    // Ekrane atspausdinkite šaldytuvo gamintoją, modelį, talpą ir kainą. Surikiuokite šaldytuvus pagal gamintoją ir kainą.
                    // ---------------------------------------------------------------------------------------------------------------------
                    RefrigeratorContainer allRefrigerators = new RefrigeratorContainer();
                    allRefrigerators.Add(firstStore);
                    allRefrigerators.Add(secondStore);
                    allRefrigerators.Sort();

                    RefrigeratorRegister allRefrigeratorsRegister = new RefrigeratorRegister(allRefrigerators);

                    allRefrigerators = allRefrigeratorsRegister.GetTop(10);
                    Console.WriteLine("\nTop 10 pigiausiu saldytuvu:");
                    InOutUtils.PrintRefrigerators(allRefrigerators);

                    // -----------------------------------------------------------------------------------------------------
                    // TASK 3
                    // Sudarykite visų šaldytuvų gamintojų sąrašą, gamintojų pavadinimus įrašykite į failą „Gamintojai.csv“. 
                    // -----------------------------------------------------------------------------------------------------
                    RefrigeratorContainer allRefrigeratorsCopy = new RefrigeratorContainer();
                    allRefrigeratorsCopy.Add(firstStore);
                    allRefrigeratorsCopy.Add(secondStore);

                    ManufacturerContainer Manufacturers = new ManufacturerContainer();
                    Manufacturers.Add(allRefrigeratorsCopy);

                    InOutUtils.PrintManufacturersToCSVFile(manufacturers, Manufacturers);

                    // ------------------------------------------------------------------------------------------
                    // TASK 4
                    // Ar yra tokių šaldytuvų gamintojų, kurių produktus galima įsigyti tik vienoje parduotuvėje?
                    // Atspausdinkite tokį gamintojų ir parduotuvių sąrašą faile „TikTen.csv“.
                    // ------------------------------------------------------------------------------------------
                    InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(firstStore, secondStore));
                    InOutUtils.PrintStoreToCSVFile(onlyThere, TaskUtils.OnlyInThisStore(secondStore, firstStore), true);    // Append second store data to file
                } else
                {
                    Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", fileRead2);
                }
            } else
            {
                Console.WriteLine("Duomenų failas \"{0}\" neegzistuoja.", fileRead1);
            }

            Console.ReadKey(); // Pause program

        }
    }
}
