using System;

namespace Lab3.Exercises.Register
{
    class DogsContainer
    {
        private Dog[] dogs;
        private int Capacity;
        public int Count { get; private set; }

        public DogsContainer(int capacity = 16) // parameter with default value
        {
            this.Capacity = capacity;
            this.dogs = new Dog[capacity];
        }
        public DogsContainer(DogsContainer container) : this() //call another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            this.dogs[this.Count++] = dog;
        }

        public void Sort()
        {

            bool flag = true;
            while(flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Dog a = this.dogs[i];
                    Dog b = this.dogs[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.dogs[i] = b;
                        this.dogs[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }
        }

        public Dog Get(int index)
        {
            return this.dogs[index];
        }

        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
                {
                    return true;
                }
            }
            return false;
        }

        // TASK 1
        /// <summary>
        /// Adds element to a container in a certain place 
        /// </summary>
        /// <param name="dog">Data to be added</param>
        /// <param name="index">place to add to</param>
        public void Put(Dog dog, int index)
        {
            this.dogs[index] = dog;
        }
        /// <summary>
        /// Inserts element to a container in a certain place
        /// </summary>
        /// <param name="dog">Data to be inserted</param>
        /// <param name="index">place to insert to</param>
        public void Insert(Dog dog, int index)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.dogs[i + 1] = this.dogs[i];
            }
            this.dogs[index] = dog;
            this.Count++;
        }
        /// <summary>
        /// Remove element that is same as <paramref name="dog"/>
        /// </summary>
        /// <param name="dog">dog element to remove</param>
        public void Remove(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].ID == dog.ID)
                {
                    
                    RemoveAt(i);
                    break;
                }
            }
        }
        /// <summary>
        /// Remove element at a certain <paramref name="index"/>
        /// </summary>
        /// <param name="index">element index</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.dogs[i] = this.dogs[i + 1];
            }
            this.Count--;
        }

        public DogsContainer Intersect(DogsContainer other)
        {
            DogsContainer result = new DogsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Dog current = this.dogs[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }


    }
}
