using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Task1
{
    class Selection
    {
        public int Rooms { get; set;  }
        public int FloorFrom { get; set; }
        public int FloorTo { get; set; }
        public int Price { get; set; }

        public Selection(int rooms, int floorFrom, int floorTo, int price)
        {
            this.Rooms = rooms;
            this.FloorFrom = floorFrom;
            this.FloorTo = floorTo;
            this.Price = price;
        }
    }
}
