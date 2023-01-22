using System;

namespace Lab5.Exercises.Register
{
    class AnimalsContainer
    {
        private Animal[] Animals;
        private int Capacity;
        public int Count { get; private set; }

        public AnimalsContainer(int capacity = 16) // parameter with default value
        {
            this.Capacity = capacity;
            this.Animals = new Animal[capacity];
        }
        public AnimalsContainer(AnimalsContainer container) : this() //call another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity) // container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            this.Animals[this.Count++] = animal;
        }

        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while(flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.Animals[i];
                    Animal b = this.Animals[i + 1];
                    if (comparator.Compare(a,b) > 0)
                    {
                        this.Animals[i] = b;
                        this.Animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public void Sort()
        {
            Sort(new AnimalsComparator());
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Animals[i];
                }
                this.Capacity = minimumCapacity;
                this.Animals = temp;
            }
        }

        public Animal Get(int index)
        {
            return this.Animals[index];
        }

        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(Animal animal, int index)
        {
            this.Animals[index] = animal;
        }

        public void Insert(Animal animal, int index)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.Animals[i + 1] = this.Animals[i];
            }
            this.Animals[index] = animal;
            this.Count++;
        }

        public void Remove(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Animals[i].ID == animal.ID)
                {
                    
                    RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.Animals[i] = this.Animals[i + 1];
            }
            this.Count--;
        }

        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.Animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }


    }
}
