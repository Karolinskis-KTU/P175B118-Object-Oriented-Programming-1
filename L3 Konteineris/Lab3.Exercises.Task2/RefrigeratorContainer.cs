using System;
namespace Lab3.Exercises.Task2
{
    class RefrigeratorContainer
    {
        private Refrigerator[] Refrigerators;
        private int Capacity;
        /// <summary>
        /// Shows how many refrigerators are in the container
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates a new refrigerator array for container
        /// </summary>
        /// <param name="capacity">Size of container</param>
        public RefrigeratorContainer(int capacity = 16)
        {
            this.Refrigerators = new Refrigerator[capacity];
        }
        /// <summary>
        /// Adds data to container
        /// </summary>
        /// <param name="container">Container data to add</param>
        public RefrigeratorContainer(RefrigeratorContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        /// <summary>
        /// Check if Refrigerator from <paramref name="manufacturer"/> with <paramref name="model"/> is already in Refrigerator container
        /// </summary>
        /// <param name="manufacturer">Manufacturer name</param>
        /// <param name="model">Model name</param>
        /// <returns>true if found in container false if not</returns>
        public bool RefrigeratorExists(string manufacturer, string model)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Refrigerators[i].Manufacturer == manufacturer && Refrigerators[i].Model == model)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// If needed adds more capacity to refrigerator array
        /// </summary>
        /// <param name="minimumCapacity">minimum capacity of refrigerator array</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Refrigerator[] temp = new Refrigerator[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Refrigerators[i];
                }
                this.Capacity = minimumCapacity;
                this.Refrigerators = temp;
            }
        }
        /// <summary>
        /// Gets a certain refrigerator by <paramref name="manufacturer"/> and <paramref name="model"/>
        /// </summary>
        /// <param name="manufacturer">Manufacturer name</param>
        /// <param name="model">Model name</param>
        /// <returns>If found returns refrigerator element</returns>
        public Refrigerator GetRefrigerator(string manufacturer, string model)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (manufacturer == this.Refrigerators[i].Manufacturer && model == this.Refrigerators[i].Model)
                {
                    return this.Refrigerators[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Adds StoreRegister <paramref name="store"/> data to refrigerator container
        /// </summary>
        /// <param name="store">Container data to add</param>
        public void Add(StoreRegister store)
        {
            for (int i = 0; i < store.Count(); i++)
            {
                Add(store.Get(i));
            }
        }
        /// <summary>
        /// Adds refrigerator element to container
        /// </summary>
        /// <param name="refrigerator">Refrigerator data to add</param>
        public void Add(Refrigerator refrigerator)
        {
            if (this.Count == this.Capacity) // if container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            if (RefrigeratorExists(refrigerator.Manufacturer, refrigerator.Model) == false) // Checks if the same refrigerator exists in container
            {
                this.Refrigerators[this.Count++] = refrigerator;
            }
        }
        /// <summary>
        /// Puts data in a certain place in refrigerators array
        /// </summary>
        /// <param name="refrigerator">Refrigerator element to put</param>
        /// <param name="index">Index to put at</param>
        public void Put(Refrigerator refrigerator, int index)
        {
            this.Refrigerators[index] = refrigerator;
        }
        /// <summary>
        /// Inserts data in a certain place in refrigerators array
        /// </summary>
        /// <param name="refrigerator">Refrigerator element to put</param>
        /// <param name="index">Index to put at</param>
        public void Insert(Refrigerator refrigerator, int index)
        {
            for (int i = this.Count; i < index; i--)
            {
                this.Refrigerators[i] = this.Refrigerators[i - 1];
            }
            this.Count++;
            this.Refrigerators[index] = refrigerator;
        }
        /// <summary>
        /// Removes refrigerator by <paramref name="refrigerator"/> data
        /// </summary>
        /// <param name="refrigerator">Refrigerator to remove</param>
        public void Remove(Refrigerator refrigerator)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Refrigerators[i] == refrigerator)
                {
                    RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Removes refrigerator from array at <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to remove at</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.Refrigerators[i] = this.Refrigerators[i + 1];
            }
            this.Count--;
        }
        /// <summary>
        /// Checks if refrigerators container has <paramref name="refrigerator"/> element
        /// </summary>
        /// <param name="refrigerator">Refrigerator element to check for</param>
        /// <returns>Returns true if container contains <paramref name="refrigerator"/> otherwise false</returns>
        public bool Contains(Refrigerator refrigerator)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Refrigerators[i].Equals(refrigerator))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Gets refrigerator element from array with <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to get by</param>
        /// <returns>Refrigerator element</returns>
        public Refrigerator Get(int index)
        {
            return this.Refrigerators[index];
        }
    
        /// <summary>
        /// Sorts refrigerator container by manufacturer and price
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Refrigerator a = Refrigerators[i];
                    Refrigerator b = Refrigerators[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.Refrigerators[i] = b;
                        this.Refrigerators[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
