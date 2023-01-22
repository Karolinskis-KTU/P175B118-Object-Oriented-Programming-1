using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class DeviceRegister
    {
        private readonly DeviceContainer allDevices = new DeviceContainer();

        /// <summary>
        /// Adds data to devices register with <paramref name="devices"/> data
        /// </summary>
        /// <param name="devices">Devices data to add</param>
        public DeviceRegister(DeviceContainer devices)
        {
            allDevices = devices;
        } 
        /// <summary>
        /// Gets top containers
        /// </summary>
        /// <param name="ammount">Ammount of refrigerators to get</param>
        /// <returns></returns>
        public DeviceContainer GetTopRefrigerators(int ammount)
        {
            List<Fridge> fridges = GetFridges();
            if (ammount > fridges.Count)
            {
                ammount = fridges.Count - 1;
            }
            DeviceContainer Filtered = new DeviceContainer();
            for (int i = ammount; i > 0; i--)
            {
                if (fridges[i].Capacity > 80 && fridges[i].Mounting == "Laisvai statomi")
                {
                    Filtered.Add(fridges[i]);
                }
            }
            return Filtered;
        }
        /// <summary>
        /// Gets all Fridges from register
        /// </summary>
        /// <returns>Returns a list of all fridges</returns>
        private List<Fridge> GetFridges()
        {
            List<Fridge> fridges = new List<Fridge>();
            for (int i = 0; i < allDevices.Count; i++)
            {
                Device device = allDevices.Get(i);
                if (device.GetType().Name == "Fridge")
                {
                    fridges.Add(device as Fridge);
                }
            }
            return fridges;
        }
        /// <summary>
        /// Counts how many different devices given <paramref name="manufacturer"/> has in store
        /// </summary>
        /// <param name="manufacturer"><paramref name="manufacturer"/> to check for</param>
        /// <returns>Returns all types of devices with their ammounts</returns>
        public int[] CountManufacturerDevice(string manufacturer)
        {
            int[] count = new int[3];
            for (int i = 0; i < allDevices.Count; i++)
            {
                if (allDevices.Get(i).Manufacturer == manufacturer)
                {
                    switch (allDevices.Get(i).GetType().Name)
                    {
                        case "Fridge":
                            count[0]++;
                            break;
                        case "Oven":
                            count[1]++;
                            break;
                        case "Kettle":
                            count[2]++;
                            break;
                        default:
                            break;
                    }
                }

            }
            return count;
        }
        /// <summary>
        /// Gets all devices with a given <paramref name="rating"/>
        /// </summary>
        /// <param name="rating"><paramref name="rating"/> to check for</param>
        /// <returns>Returns container with all devices with <paramref name="rating"/></returns>
        public DeviceContainer GetDevicesWithRating(string rating)
        {
            DeviceContainer filtered = new DeviceContainer();
            for (int i = 0;i < allDevices.Count;i++)
            {
                if (allDevices.Get(i).EnergyClass == rating)
                {
                    filtered.Add(allDevices.Get(i));
                }
            }
            return filtered;
        }

    }
}
