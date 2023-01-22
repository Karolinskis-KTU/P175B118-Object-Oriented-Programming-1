namespace Lab3.Exercises.Task2
{
    class TaskUtils
    {
        /// <summary>
        /// Finds all products that are only in a certain store container
        /// </summary>
        /// <param name="store1">First store container</param>
        /// <param name="store2">Store container to comapre to</param>
        /// <returns>Returns store information and all products that only <paramref name="store1"/> has</returns>
        public static StoreRegister OnlyInThisStore(StoreRegister store1, StoreRegister store2)
        {
            StoreRegister Filtered = new StoreRegister
            {
                Name = store1.Name,
                Adress = store1.Adress,
                Phone = store1.Phone
            };
            for (int i = 0; i < store1.Count(); i++)
            {
                int notFound = 0;
                Refrigerator refrigerator1 = store1.Get(i);
                for (int j = 0; j < store2.Count(); j++)
                {
                    Refrigerator refrigerator2 = store2.Get(j);
                    if (refrigerator1.GetHashCode() == refrigerator2.GetHashCode())
                    {
                        notFound = 0;
                        break;
                    }
                    else
                    {
                        notFound++;
                    }
                }

                if (notFound == store2.Count())
                {
                    Filtered.Add(refrigerator1);
                }
            }
            return Filtered;
        }
    }
}
