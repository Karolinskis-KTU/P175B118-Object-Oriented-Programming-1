using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class DeviceContainer
    {
        private Device[] Devices;
        private int Capacity;
        /// <summary>
        /// Shows how many devices are in the container
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates new device array for container
        /// </summary>
        /// <param name="capacity">Size of container</param>
        public DeviceContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.Devices = new Device[capacity];
        }
        /// <summary>
        /// Adds data to container
        /// </summary>
        /// <param name="container">Container to add</param>
        public DeviceContainer(DeviceContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        /// <summary>
        /// Adds manufacturer string to container
        /// </summary>
        /// <param name="device">Device to try to add</param>
        public void Add(Device device)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity + 1);
            }
            this.Devices[this.Count++] = device;
        }
        /// <summary>
        /// Store data to add
        /// </summary>
        /// <param name="store">Store's devices to add</param>
        public void Add(Register store)
        {
            for (int i = 0; i < store.Count(); i++)
            {
                Add(store.Get(i));
            }
        }

        /// <summary>
        /// If needed adds more capacity to container
        /// </summary>
        /// <param name="minimumCapacity">Minimum capacity of container</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Device[] temp = new Device[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Devices[i];
                }
                this.Capacity = minimumCapacity;
                this.Devices = temp;
            }
        }
        /// <summary>
        /// Get element from container
        /// </summary>
        /// <param name="index">Index to get by</param>
        /// <returns>Returns element by <paramref name="index"/></returns>
        public Device Get(int index)
        {
            return this.Devices[index];
        }
        /// <summary>
        /// Checks if container has <paramref name="device"/>
        /// </summary>
        /// <param name="device"><paramref name="device"/> to check for</param>
        /// <returns>Returns true if container has <paramref name="device"/> otherwise false</returns>
        public bool Contains(Device device)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Devices[i].Equals(device))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sorts the container
        /// </summary>
        public void Sort(DeviceComparatorByPrice comparator)
        {
            // Bubble sort
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Device a = this.Devices[i];
                    Device b = this.Devices[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.Devices[i] = b;
                        this.Devices[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
    }
}
