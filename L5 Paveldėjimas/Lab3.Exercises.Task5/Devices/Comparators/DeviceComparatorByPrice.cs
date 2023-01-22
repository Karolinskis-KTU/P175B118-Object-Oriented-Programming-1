using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class DeviceComparatorByPrice : DeviceComparator
    {
        public override int Compare(Device a, Device b)
        {
            if (a.Price == b.Price)
            {
                return a.Manufacturer.CompareTo(b.Manufacturer);
            }
            return a.Price.CompareTo(b.Price);
        }
    }
}
