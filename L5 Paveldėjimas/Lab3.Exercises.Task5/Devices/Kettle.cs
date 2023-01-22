using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class Kettle : Device
    {
        /// <summary>
        /// Power of the kettle
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Volume of the kettle
        /// </summary>
        public int Volume { get; set; }
        /// <summary>
        /// Constructor of class
        /// </summary>
        /// <param name="manufacturer">Manufacturer of kettle</param>
        /// <param name="model">Model of kettle</param>
        /// <param name="energyClass">Energy class of kettle</param>
        /// <param name="colour">Colour of kettle</param>
        /// <param name="price">Price of kettle</param>
        /// <param name="power">Power of kettle</param>
        /// <param name="volume">Volume size of kettle</param>
        public Kettle(string manufacturer, string model, string energyClass, string colour, double price, int power, int volume) : base(manufacturer, model, energyClass, colour, price)
        {
            this.Power = power;
            this.Volume = volume;
        }
        /// <summary>
        /// Puts all Kettle data to single line
        /// </summary>
        /// <returns>string with formated Kettle data</returns>
        public override string ToString()
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";

            return String.Format(spacing, "Virdulys", this.Manufacturer, this.Model, this.EnergyClass, this.Colour, this.Price, this.Volume, "-", "-", "-", "-", "-", this.Power, "-");
        }
    }
}
