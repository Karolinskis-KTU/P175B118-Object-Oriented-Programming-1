using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Exercises.Task2
{
    class TaskUtils
    {
        /// <summary>
        /// Counts how many many products from a certain manufacturer there are in the list
        /// </summary>
        /// <param name="Refrigerators"></param>
        /// <param name="manufacturer"></param>
        /// <returns></returns>
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
        /// <param name="Refrigerators"></param>
        /// <returns></returns>
        public static double FindLowestPrice(List<Refrigerator> Refrigerators)
        {
            double lowestPrice = 99999;
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                if (lowestPrice > refrigerator.Price && refrigerator.Mounting.Equals("Laisvai statomi") && refrigerator.Capacity >= 80)
                {
                    lowestPrice = refrigerator.Price;

                }
            }

            return lowestPrice;
        }
        /// <summary>
        /// Finds all products with the same price with a mounting paramater "Laisvai statomi" and a capacity that is equal to or over 80
        /// </summary>
        /// <param name="Refrigerators"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public static List<Refrigerator> FindAllWithSamePrice (List<Refrigerator> Refrigerators, double price)
        {
            List<Refrigerator> Filtered = new List<Refrigerator>();
            foreach (Refrigerator refrigerator in Refrigerators)
            {
                if (refrigerator.Price == price && refrigerator.Mounting.Equals("Laisvai statomi") && refrigerator.Capacity >= 80)
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
    }
}
