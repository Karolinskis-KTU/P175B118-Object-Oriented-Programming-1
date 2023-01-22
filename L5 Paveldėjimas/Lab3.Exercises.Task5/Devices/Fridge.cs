using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class Fridge : Device
    {
        /// <summary>
        /// Capacity of the refrigerator
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// Mounting type of the refrigerator
        /// </summary>
        public string Mounting { get; set; }
        /// <summary>
        /// Bool if the refrigerator has freezer
        /// </summary>
        public Freezer Freezer { get; set; }
        /// <summary>
        /// Height of the refrigerator
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Width of the refrigerator
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// Depth of the refrigerator
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Constructor to access data
        /// </summary>
        /// <param name="manufacturer">Manufacturer of refrigertator</param>
        /// <param name="model">Model of refrigerator</param>
        /// <param name="energyClass">Energy class of refrigerator</param>
        /// <param name="colour">Colour of refrigerator</param>
        /// <param name="price">Price of refrigerator</param>
        /// <param name="capacity">Capacity of refrigerator</param>
        /// <param name="mounting">Mounting type of refrigerator</param>
        /// <param name="freezer">Bool if refrigrator has freezer</param>
        /// <param name="height">Height of the refrigerator</param>
        /// <param name="width">Width of the refrigerator</param>
        /// <param name="depth">Depth of the refrigerator</param>
        public Fridge(string manufacturer, string model, string energyClass, string colour, double price, int capacity, string mounting, Freezer freezer, int height, int width, int depth) : base(manufacturer, model, energyClass, colour, price)
        {
            this.Capacity = capacity;
            this.Mounting = mounting;
            this.Freezer = freezer;
            this.Height = height;
            this.Width = width;
            this.Depth = depth;
        }
        /// <summary>
        /// Puts all Fridge data to single line
        /// </summary>
        /// <returns>string with formated fridge data</returns>
        public override string ToString()
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";

            return String.Format(spacing, "Šaldytuvas", this.Manufacturer, this.Model, this.EnergyClass, this.Colour, this.Price, this.Capacity, this.Mounting, this.Freezer, this.Height, this.Width, this.Depth, "-", "-");
        }
    }
}
