namespace Lab3.Exercises.Task2
{
    class ManufacturerContainer
    {
        private string[] Manufacturers;
        private int Capacity;
        /// <summary>
        /// Shows how many manufacturers are in the container
        /// </summary>
        public int Count { get; private set; }
        
        /// <summary>
        /// Creates new manufacturer array for container
        /// </summary>
        /// <param name="capacity">Size of container</param>
        public ManufacturerContainer(int capacity = 32)
        {
            this.Manufacturers = new string[capacity];
        }
        /// <summary>
        /// Adds data to container
        /// </summary>
        /// <param name="container">Container data to add</param>
        public ManufacturerContainer(ManufacturerContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        /// <summary>
        /// Checks if Manufacturers array already has <paramref name="manufacturer"/>
        /// </summary>
        /// <param name="manufacturer">Manufacturer name</param>
        /// <returns>true if found in container false if not</returns>
        public bool ManufacturerExists(string manufacturer)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Manufacturers[i] == manufacturer)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// If needed adds more capacity to manufacturer array
        /// </summary>
        /// <param name="minimumCapacity">minimum capacity of manufacturer array</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                string[] temp = new string[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Manufacturers[i];
                }
                this.Capacity = minimumCapacity;
                this.Manufacturers = temp;
            }
        }
        /// <summary>
        /// Add manufacturer to container from Refrigerator container
        /// </summary>
        /// <param name="refrigerators">RefrigeratorContainer to add from</param>
        public void Add(RefrigeratorContainer refrigerators)
        {
            for (int i = 0; i < refrigerators.Count; i++)
            {
                Add(refrigerators.Get(i).Manufacturer);
            }
        }
        /// <summary>
        /// Adds manufacturer string to container
        /// </summary>
        /// <param name="manufacturer">Manufacturer name to try to add</param>
        public void Add(string manufacturer)
        {
            if (this.Count == this.Capacity) // if container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            if (ManufacturerExists(manufacturer) == false) // Checks if the same manufacturer exists in container
            {
                this.Manufacturers[this.Count++] = manufacturer;
            }
        }
        /// <summary>
        /// Puts data in a certain place in manufacturer array
        /// </summary>
        /// <param name="manufacturer">Manufacturer string to put</param>
        /// <param name="index">Index to put at</param>
        public void Put(string manufacturer, int index)
        {
            this.Manufacturers[index] = manufacturer;
        }
        /// <summary>
        /// Inserts data in a certain place in manufacturer array
        /// </summary>
        /// <param name="manufacturer">Manufacturer to insert</param>
        /// <param name="index">Index to put at</param>
        public void Insert(string manufacturer, int index)
        {
            for (int i = this.Count; i < index; i--)
            {
                this.Manufacturers[i] = this.Manufacturers[i - 1];
            }
            this.Count++;
            this.Manufacturers[index] = manufacturer;
        }
        /// <summary>
        /// Removes manufacturer element by <paramref name="manufacturer"/>
        /// </summary>
        /// <param name="refrigerator">Manufacturer to remove</param>
        public void Remove(string manufacturer)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Manufacturers[i] == manufacturer)
                {
                    RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Removes element from array at <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to remove at</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.Manufacturers[i] = this.Manufacturers[i + 1];
            }
            this.Count--;
        }
        /// <summary>
        /// Checks if manufacturer container has manufacturer
        /// </summary>
        /// <param name="manufacturer">Refrigerator element to check for</param>
        /// <returns>Returns true if container contains <paramref name="manufacturer"/>. Otherwise false</returns>
        public bool Contains(string manufacturer)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Manufacturers[i].Equals(manufacturer))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Gets manufacturer element from array with <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to get by</param>
        /// <returns>Refrigerator element</returns>
        public string Get(int index)
        {
            return this.Manufacturers[index];
        }
    }
}
