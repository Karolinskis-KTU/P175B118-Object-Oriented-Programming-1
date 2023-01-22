using System;
using System.Collections.Generic;

namespace Lab2.Exercises.Task2
{
    class TaskUtils
    {
        /// <summary>
        /// Counts how many many products from a certain manufacturer there are in the list
        /// </summary>
        /// <param name="Refrigerators">Refrigerators list</param>
        /// <param name="manufacturer">Certain manufacturer</param>
        /// <returns>Returns a number of how many refrigerators have the given manufacturer name</returns>
        public static int CountManufacturerModels(List<Refrigerator> Refrigerators, string manufacturer)
        {
            int count = 0;
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                if(refrigerator.Manufacturer.Equals(manufacturer))
                {
                    count++;
                }
            }
            return count++;
        }
        /// <summary>
        /// Finds The Lowest price of a product with a mounting paramater "Laisvai statomi" and a capacity that is equal to or over 80
        /// </summary>
        /// <param name="Refrigerators">Refrigerator list</param>
        /// <returns>Returns the lowest price in the given list</returns>
        public static double FindLowestPrice(List<Refrigerator> Refrigerators)
        {
            double lowestPrice = 99999;
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                if (lowestPrice > refrigerator && refrigerator.Mounting.Equals("Laisvai statomi") && refrigerator.Capacity >= 80)
                {
                    lowestPrice = refrigerator.Price;

                }
            }

            return lowestPrice;
        }
        /// <summary>
        /// Finds all products with the same price with a mounting paramater "Laisvai statomi" and a capacity that is equal to or over 80
        /// </summary>
        /// <param name="Refrigerators">Refrigerator list</param>
        /// <param name="price">Certain price</param>
        /// <returns>Returns a list of all product with the given price</returns>
        public static List<Refrigerator> FindAllWithSamePrice (List<Refrigerator> Refrigerators, double price)
        {
            List<Refrigerator> Filtered = new List<Refrigerator>();
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                if (price == refrigerator && refrigerator.Mounting.Equals("Laisvai statomi") && refrigerator.Capacity >= 80)
                {
                    Filtered.Add(refrigerator);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Filter List by capacity
        /// </summary>
        /// <param name="Refrigerators"></param>
        /// <returns>Returns a List with all products that have the mounting paramater "Laisvai statomi" and a capacity that is equal to or over 80</returns>
        public static List<Refrigerator> FilterByCapacity(List<Refrigerator> Refrigerators)
        {
            List<Refrigerator> Filtered = new List<Refrigerator>();
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                if(refrigerator.Mounting.Equals("Laisvai statomi") && refrigerator.Capacity >= 80)
                {
                    Filtered.Add(refrigerator);

                }
            }
            return Filtered;
        }
        /// <summary>
        /// Finds the highest price in <paramref name="store"/> list
        /// </summary>
        /// <param name="store">Store list</param>
        /// <returns>Retruns the highest priced item price</returns>
        public static double FindHighestPrice(Store store)
        {
            double highestPrice = 0;
            for (int i = 0; i < store.CountRefrigerators(); i++)
            {
                Refrigerator refrigerator = store.GetElement(i);
                if (highestPrice < refrigerator && refrigerator.Capacity >= 80)
                {
                    highestPrice = refrigerator.Price;
                }
            }
            return highestPrice;
        }
        /// <summary>
        /// Finds the manufacturer with the priciest product in <paramref name="store"/> list
        /// </summary>
        /// <param name="store">Store list</param>
        /// <returns>Returns name of the manufacturer</returns>
        public static string FindHighestPriceManufacturer(Store store)
        {
            string manufacturer = "";
            double highestPrice = 0;
            for (int i = 0; i < store.CountRefrigerators(); i++)
            {
                Refrigerator refrigerator = store.GetElement(i);
                if (highestPrice < refrigerator && refrigerator.Capacity >= 80)
                {
                    highestPrice = refrigerator.Price;
                    manufacturer = refrigerator.Manufacturer;
                }
            }
            return manufacturer;
        }
        /// <summary>
        /// Finds all products with the same <paramref name="price"/> in a given <paramref name="store"/> list
        /// </summary>
        /// <param name="store">Store list</param>
        /// <param name="price">Price to find at</param>
        /// <returns>A list of all product with <paramref name="price"/></returns>
        public static Store FindWithSamePrice(Store store, double price)
        {
            Store Filtered = new Store
            {
                StoreName = store.StoreName,
                StoreAdress = store.StoreAdress,
                StorePhone = store.StorePhone
            };
            for (int i = 0; i < store.CountRefrigerators(); i++)
            {
                Refrigerator refrigerator = store.GetElement(i);
                if (price == refrigerator && refrigerator.Capacity >= 80)
                {
                    Filtered.Add(refrigerator);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Finds all products that are only in a certain store list
        /// </summary>
        /// <param name="store1">First store list</param>
        /// <param name="store2">Store list to comapre to</param>
        /// <returns>Returns store information and all products that only <paramref name="store1"/> has</returns>
        public static Store OnlyInThisStore(Store store1, Store store2)
        {
            Store Filtered = new Store
            {
                StoreName = store1.StoreName,
                StoreAdress = store1.StoreAdress,
                StorePhone = store1.StorePhone
            };
            for (int i = 0; i < store1.CountRefrigerators(); i++)
            {
                int notFound = 0;
                Refrigerator refrigerator1 = store1.GetElement(i);
                for (int j = 0; j < store2.CountRefrigerators(); j++)
                {
                    Refrigerator refrigerator2 = store2.GetElement(j);
                    if (refrigerator1.GetHashCode() == refrigerator2.GetHashCode())
                    {
                        notFound = 0;
                        break;
                    } else
                    {
                        notFound++;
                    }
                }

                if ( notFound == store2.CountRefrigerators() )
                {
                    
                    Filtered.Add(refrigerator1);
                }
            }
            return Filtered;
        }
    }
}
