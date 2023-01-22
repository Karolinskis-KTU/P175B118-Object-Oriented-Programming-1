namespace Lab5.Exercises.Task5
{
    class Register
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
        private readonly DeviceContainer allDevices = new DeviceContainer();
        /// <summary>
        /// Creates new store
        /// </summary>
        public Register()
        {
            this.allDevices = new DeviceContainer();
        }
        /// <summary>
        /// Adds data to refrigerator register with <paramref name="store"/> data
        /// </summary>
        /// <param name="store">Store data to add</param>
        public Register(Register store)
        {
            this.Name = store.Name;
            this.Adress = store.Adress;
            this.Phone = store.Phone;
            this.allDevices = store.allDevices;
        }

        /// <summary>
        /// Adds refrigerator data to refrigerator container
        /// </summary>
        /// <param name="refrigerator">Refrigerator data to add</param>
        public void Add(Device device)
        {
            allDevices.Add(device);
        }


        /// <summary>
        /// Gives the ammount of items in register
        /// </summary>
        /// <returns>Returns integer of items</returns>
        public int Count()
        {
            return allDevices.Count;
        }
        /// <summary>
        /// Gets device element from register
        /// </summary>
        /// <param name="i">Index of element</param>
        /// <returns>Returns device</returns>
        public Device Get(int i)
        {
            return allDevices.Get(i);
        }
    }
}
