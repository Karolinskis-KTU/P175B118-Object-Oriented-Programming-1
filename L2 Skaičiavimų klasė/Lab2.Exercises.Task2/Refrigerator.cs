using System.Collections.Generic;

namespace Lab2.Exercises.Task2
{
    class Refrigerator
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string EnergyClass { get; set; }
        public string Mounting { get; set; }
        public string Colour { get; set; }
        public Freezer Freezer { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        /// <summary>
        /// Constructor to access data
        /// </summary>
        /// <param name="manufacturer">Name of refridgerator's manufacturer</param>
        /// <param name="model">Model of refrigerator</param>
        /// <param name="capacity">Capacity of refrigerator</param>
        /// <param name="energyclass">Energy class of refrigerator</param>
        /// <param name="mounting">Mounting type</param>
        /// <param name="colour">Colour of refrigerator</param>
        /// <param name="freezer">bool if fridge has freezer</param>
        /// <param name="price">Price of refrigerator</param>
        /// <param name="height">Height of refrigerator</param>
        /// <param name="width">Width of refrigerator</param>
        /// <param name="depth">Depth of refrigerator</param>
        public Refrigerator(string manufacturer, string model, int capacity, string energyclass, string mounting, string colour, Freezer freezer, int price, int height, int width, int depth)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Capacity = capacity;
            this.EnergyClass = energyclass;
            this.Mounting = mounting;
            this.Colour = colour;
            this.Freezer = freezer;
            this.Price = price;
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }
        public static bool operator <(double price, Refrigerator refrigerator)
        {
            return price < refrigerator.Price;
        }
        public static bool operator >(double price, Refrigerator refrigerator)
        {
            return price > refrigerator.Price;
        }
        public static bool operator ==(double price, Refrigerator refrigerator)
        {
            return price == refrigerator.Price;
        }
        public static bool operator !=(double price, Refrigerator refrigerator)
        {
            return price != refrigerator.Price;
        }
        public override bool Equals(object obj)
        {
            return obj is Refrigerator refrigerator &&
                   Manufacturer == refrigerator.Manufacturer &&
                   Model == refrigerator.Model &&
                   Capacity == refrigerator.Capacity &&
                   EnergyClass == refrigerator.EnergyClass &&
                   Mounting == refrigerator.Mounting &&
                   Colour == refrigerator.Colour &&
                   Freezer == refrigerator.Freezer &&
                   Price == refrigerator.Price &&
                   Height == refrigerator.Height &&
                   Width == refrigerator.Width &&
                   Depth == refrigerator.Depth;
        }
        public override int GetHashCode()
        {
            int hashCode = 138111570;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            return hashCode;
        }
    }
}
