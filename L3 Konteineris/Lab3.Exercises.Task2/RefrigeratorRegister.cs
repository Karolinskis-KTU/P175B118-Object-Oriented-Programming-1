namespace Lab3.Exercises.Task2
{
    class RefrigeratorRegister
    {
        private readonly RefrigeratorContainer allRefrigerators = new RefrigeratorContainer();
        /// <summary>
        /// Adds data to refrigerator register with <paramref name="store"/> data
        /// </summary>
        /// <param name="refrigerators">Refrigerator data to add</param>
        public RefrigeratorRegister( RefrigeratorContainer refrigerators)
        {
            allRefrigerators = refrigerators;
        }

        /// <summary>
        /// Finds highest price in Refrigerator container
        /// </summary>
        /// <returns>Returns highest price found</returns>
        public double FindLowestPrice()
        {
            double highestPrice = 0;
            for (int i = 0; i < allRefrigerators.Count; i++)
            {
                Refrigerator refrigerator = allRefrigerators.Get(i);
                if (highestPrice < refrigerator && refrigerator.Capacity >= 80)
                {
                    highestPrice = refrigerator.Price;
                }
            }
            return highestPrice;
        }
        /// <summary>
        /// Gets the top most items from Container
        /// </summary>
        /// <param name="ammount">Ammount of items to get</param>
        /// <returns>Returns container with top items</returns>
        public RefrigeratorContainer GetTop(int ammount)
        {
            if (ammount > allRefrigerators.Count)
            {
                ammount = allRefrigerators.Count;
            }
            RefrigeratorContainer Filtered = new RefrigeratorContainer();
            for (int i = ammount - 1; i >= 0; i--)
            {
                Filtered.Add(allRefrigerators.Get(i));
            }
            return Filtered;
        } 
    }
}
