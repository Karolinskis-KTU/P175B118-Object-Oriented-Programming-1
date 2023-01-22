using System;
using System.Collections.Generic;

namespace Lab3.Exercises.Task2
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
        public override string ToString()
        {
            return String.Format("| {0, -15} | {1, -15} | {2, 10} | {3, -15} | {4, -20} | {5, -20} | {6, -10} | {7, 5} | {8, 10} | {9, 10} | {10, 5} |", this.Manufacturer, this.Model, this.Capacity, this.EnergyClass, this.Mounting, this.Colour, this.Freezer, this.Price, this.Height, this.Width, this.Depth);
        }
        public override int GetHashCode()
        {
            int hashCode = 138111570;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Manufacturer);
            return hashCode;
        }
        /// <summary>
        /// Compare by manufacturer and price
        /// </summary>
        /// <param name="other">Refrigerator to compare to</param>
        /// <returns></returns>
        public int CompareTo(Refrigerator other)
        {
            if (this.Price == other.Price)
            {
                return this.Manufacturer.CompareTo(other.Manufacturer);
            }
            return other.Price.CompareTo(this.Price) * -1;
        }
    }
}
