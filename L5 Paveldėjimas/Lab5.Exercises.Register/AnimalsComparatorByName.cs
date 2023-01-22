using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Register
{
    class AnimalsComparatorByName : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            if (a.Name == b.Name)
            {
                return a.ID.CompareTo(b.ID);
            } else
            {
                return a.Name.CompareTo(b.Name);
            }
            
        }
    }
}
