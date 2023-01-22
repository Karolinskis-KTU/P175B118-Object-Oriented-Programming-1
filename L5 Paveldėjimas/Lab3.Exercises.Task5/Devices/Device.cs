using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    public abstract class Device
    {
        /// <summary>
        /// Name of device's manufacturer
        /// </summary>
        public string Manufacturer { get; set; }
        /// <summary>
        /// Model of the device
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Device's energy class
        /// </summary>
        public string EnergyClass { get; set; }
        /// <summary>
        /// Colour of the device
        /// </summary>
        public string Colour { get; set; }
        /// <summary>
        /// Price of the device
        /// </summary>
        public double Price { get; set; }

        public Device(string manufacturer, string model, string energyClass, string colour, double price)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.EnergyClass = energyClass;
            this.Colour = colour;
            this.Price = price;
        }
        /// <summary>
        /// Compares two devices
        /// </summary>
        /// <param name="other">Device to compare to</param>
        public int CompareTo(Device other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                return this.Manufacturer.CompareTo(other.Manufacturer);
            }
            return result;
        }
        /// <summary>
        /// Checks if two objects have the same data
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns>True if both object are eaxtly the same otherwise false</returns>
        public override bool Equals(object obj)
        {
            return obj is Device device &&
                   Manufacturer == device.Manufacturer &&
                   Model == device.Model &&
                   EnergyClass == device.EnergyClass &&
                   Colour == device.Colour &&
                   Price == device.Price;
        }
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 468886024;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EnergyClass);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Colour);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
