using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace Lab2.Exercises.Task1
{
    class InOutUtils
    {
        public static FlatsRegister ReadFlats(string fileName)
        {
            FlatsRegister Flats = new FlatsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                int area = int.Parse(Values[1]);
                int rooms = int.Parse(Values[2]);
                int price = int.Parse(Values[3]);
                string phoneNumber = Values[4];
                Flat flat = new Flat(id, area, rooms, price, phoneNumber);
                if (!Flats.Contains(flat))
                {
                    Flats.Add(flat);
                }
            }
            return Flats;
        }

        public static Selection ReadSelections(string fileName)
        {
            string[] Lines = File.ReadAllLines(fileName);
            string[] Values = Lines[0].Split(';');
            int rooms = int.Parse(Values[0]);
            int floorFrom = int.Parse(Values[1]);
            int floorTo = int.Parse(Values[2]);
            int price = int.Parse(Values[3]);

            Selection selection = new Selection(rooms, floorFrom, floorTo, price);
            return selection;
        }
        public static void PrintFlatRegister(FlatsRegister Flats)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,15} | {2,-12} | {3,-12} | {4,-12} |", "Buto.Nr.", "Bendras plotas", "Kambariu sk.", "Kaina", "Telefono nr.");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < Flats.FlatsCount(); i++)
            {
                Flat flat = Flats.GetElement(i);
                Console.WriteLine("| {0,8} | {1,15} | {2,12} | {3,12} | {4,-12} |", flat.ID, flat.Area, flat.Rooms, flat.Price, flat.PhoneNumber);
            }
            Console.WriteLine(new string('-', 74));
        }
    }
}
