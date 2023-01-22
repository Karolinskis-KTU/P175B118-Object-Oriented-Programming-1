using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class Oven : Device
    {
        /// <summary>
        /// Power rating of the oven
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Ammount of different programs that the oven has
        /// </summary>
        public int ProgramCount { get; set; }

        /// <summary>
        /// Constructor to access data
        /// </summary>
        /// <param name="manufacturer">Manufacturer of the oven</param>
        /// <param name="model">Model of the oven</param>
        /// <param name="energyClass">Energy class of the oven</param>
        /// <param name="colour">Colour of the oven</param>
        /// <param name="price">Price of the oven</param>
        /// <param name="power">Power rating of the oven</param>
        /// <param name="programCount">Ammount of different programs that the oven has</param>
        public Oven(string manufacturer, string model, string energyClass, string colour, double price, int power, int programCount) : base(manufacturer, model, energyClass, colour, price)
        {
            this.Power = power;
            this.ProgramCount = programCount;
        }
        /// <summary>
        /// Puts all Oven data to single line
        /// </summary>
        /// <returns>string with formated Oven data</returns>
        public override string ToString()
        {
            string spacing = "| {0,-15} | {1,-15} | {2,-15} | {3,-15} | {4,-20} | {5,-6} | {6,-15} | {7,-20} | {8,-10} | {9,-8} | {10,-8} | {11,-8} | {12,-10} | {13,-20} |";

            return String.Format(spacing, "Mikrobanginė", this.Manufacturer, this.Model, this.EnergyClass, this.Colour, this.Price, "-", "-", "-", "-", "-", "-", this.Power, this.ProgramCount);

        }
    }
}
