using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Task1
{
    class Flat
    {
        public int ID { get; set; }
        public int Area { get; set; }
        public int Rooms { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }

        public Flat(int id, int area, int rooms, int price, string phoneNumber)
        {
            this.ID = id;
            this.Area = area;
            this.Rooms = rooms;
            this.Price = price;
            this.PhoneNumber = phoneNumber;
        }
        public int Floor
        {
            get
            {
                int floor = 0;

                for (int i = 1; i <= 27; i += 3)
                {
                    floor++;
                    if ((this.ID % 27) >= i && (this.ID % 27) < i + 3)
                    {
                        return floor;
                    }
                }

                return floor;

            }
        }
    }
}
