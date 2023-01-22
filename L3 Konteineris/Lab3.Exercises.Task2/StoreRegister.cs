namespace Lab3.Exercises.Task2
{
    class StoreRegister
    {
        /// <summary>
        /// Name of the store
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Adress of the store
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Phone number of the store
        /// </summary>
        public string Phone { get; set; }
        private readonly RefrigeratorContainer allRefrigerators = new RefrigeratorContainer();
        /// <summary>
        /// Creates new store
        /// </summary>
        public StoreRegister()
        {
            this.allRefrigerators = new RefrigeratorContainer();
        }
        /// <summary>
        /// Adds data to refrigerator register with <paramref name="store"/> data
        /// </summary>
        /// <param name="store">Store data to add</param>
        public StoreRegister(StoreRegister store)
        {
            this.Name = store.Name;
            this.Adress = store.Adress;
            this.Phone = store.Phone;
            this.allRefrigerators = store.allRefrigerators;
        }

        /// <summary>
        /// Adds refrigerator data to refrigerator container
        /// </summary>
        /// <param name="refrigerator">Refrigerator data to add</param>
        public void Add(Refrigerator refrigerator)
        {
            allRefrigerators.Add(refrigerator);
        }

        /// <summary>
        /// Finds highest price in Refrigerator container
        /// </summary>
        /// <returns>Returns highest price found</returns>
        public double FindHighestPrice()
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
        /// Finds all items with same <paramref name="price"/>
        /// </summary>
        /// <param name="price">Price to compare to</param>
        /// <returns>All items with given <paramref name="price"/></returns>
        public StoreRegister FindWithSamePrice(double price)
        {
            StoreRegister Filtered = new StoreRegister
            {
                Name = this.Name,
                Adress = this.Adress,
                Phone = this.Phone
            };
            for (int i = 0; i < allRefrigerators.Count; i++)
            {
                Refrigerator refrigerator = allRefrigerators.Get(i);
                if (price == refrigerator && refrigerator.Capacity >= 80)
                {
                    Filtered.Add(refrigerator);
                }
            }
            return Filtered;
        }
        public int Count()
        {
            return allRefrigerators.Count;
        }
        public Refrigerator Get(int i)
        {
            return allRefrigerators.Get(i);
        }
    }
}
