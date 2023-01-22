using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Exercises.Task1
{
    class FlatsRegister
    {
        private List<Flat> AllFlats;

        public FlatsRegister()
        {
            AllFlats = new List<Flat>();
        }

        public FlatsRegister(List<Flat> Flats)
        {
            AllFlats = new List<Flat>();
            foreach (Flat flat in Flats)
            {
                this.AllFlats.Add(flat);
            }
        }
        public void Add(Flat flat)
        {
            AllFlats.Add(flat);
        }
        public int FlatsCount()
        {
            return this.AllFlats.Count;
        }
        public Flat GetElement(int index)
        {
            return AllFlats[index];
        }
        public bool Contains(Flat flat)
        {
            return AllFlats.Contains(flat);
        }

        public FlatsRegister FilterBySelectionCriteria(Selection selection)
        {
            FlatsRegister Filtered = new FlatsRegister();
            foreach (Flat flat in this.AllFlats)
            {
                if (selection.Rooms == flat.Rooms && selection.FloorFrom <= flat.Floor && flat.Floor <= selection.FloorTo && flat.Price < selection.Price)
                {
                    Filtered.Add(flat);
                }
            }
            return Filtered;
        }
    }
}
