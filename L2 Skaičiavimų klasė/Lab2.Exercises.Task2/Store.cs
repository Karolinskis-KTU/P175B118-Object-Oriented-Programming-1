using System.Collections.Generic;

namespace Lab2.Exercises.Task2
{
    class Store
    {
        /// <summary>
        /// Name of the store
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// Adress of the store
        /// </summary>
        public string StoreAdress { get; set; }
        /// <summary>
        /// Phone number of the store
        /// </summary>
        public string StorePhone { get; set; }
        /// <summary>
        /// Refrigerators list
        /// </summary>
        private List<Refrigerator> refrigerators;

        /// <summary>
        /// Create new store list
        /// </summary>
        public Store()
        {
            refrigerators = new List<Refrigerator>();
        }
        /// <summary>
        /// Create new store list with <paramref name="refrigerators"/> data
        /// </summary>
        /// <param name="refrigerators">List of refrigerators</param>
        public Store(List<Refrigerator> refrigerators)
        {
            refrigerators = new List<Refrigerator>();
            foreach (Refrigerator refrigerator in refrigerators)
            {
                refrigerators.Add(refrigerator);
            }
        }
        /// <summary>
        /// Adds refrigerator data to refrigerator list
        /// </summary>
        /// <param name="refrigerator">Refrigerator data</param>
        public void Add(Refrigerator refrigerator)
        {
            refrigerators.Add(refrigerator);
        }
        /// <summary>
        /// Counts how many refrigerators are in a list
        /// </summary>
        /// <returns>Returns a number of how many refrigertors are in the list</returns>
        public int CountRefrigerators()
        {
            return this.refrigerators.Count;
        }
        /// <summary>
        /// Gets a certain element by the given <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index of element</param>
        /// <returns>Returns selected element</returns>
        public Refrigerator GetElement(int index)
        {
            return refrigerators[index];
        }
    }
}
