using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Exercises.Task2
{
    class Refrigerator
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string EnergyClass { get; set; }
        public string Mounting { get; set; }
        public string Colour { get; set; }
        public bool Freezer { get; set; }
        public double Price { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }

        public Refrigerator(string manufacturer, string model, int capacity, string energyclass, string mounting, string colour, bool freezer, int price, int height, int width, int depth)
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
    }
}
