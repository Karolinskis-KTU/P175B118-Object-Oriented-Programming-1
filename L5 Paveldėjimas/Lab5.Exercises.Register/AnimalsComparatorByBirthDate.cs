using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByBirthDate : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            if (a.BirthDate == b.BirthDate)
            {
                return a.ID.CompareTo(b.ID);
            } else
            {
                return a.BirthDate.CompareTo(b.BirthDate);
            }
        }
    }
}
