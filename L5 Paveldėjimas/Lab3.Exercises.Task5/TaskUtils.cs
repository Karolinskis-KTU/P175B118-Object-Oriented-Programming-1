using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Exercises.Task5
{
    class TaskUtils
    {
        /// <summary>
        /// Checks what devices are only in a certain store
        /// </summary>
        /// <param name="store1">Store to compare by</param>
        /// <param name="store2">Store to compare to</param>
        /// <param name="store3">Store to compare to</param>
        /// <returns>Returns all devices that are only in <paramref name="store1"/></returns>
        public static Register OnlyInThisStore(Register store1, Register store2, Register store3)
        {
            Register Filtered = new Register
            {
                Name = store1.Name,
                Adress = store1.Adress,
                Phone = store1.Phone
            };
            for (int i = 0; i < store1.Count(); i++)
            {
                bool found = false;
                Device device1 = store1.Get(i);


                for (int j = 0; j < store2.Count(); j++)
                {
                    Device device2 = store2.Get(j);
                    if (device1.Equals(device2))
                    {
                        found = true;
                        break;
                    }
                }

                for (int j = 0; j < store3.Count(); j++)
                {
                    Device device3 = store3.Get(j);
                    if (device1.Equals(device3))
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Filtered.Add(device1);
                }
            }
            return Filtered;
        }

    }
}
