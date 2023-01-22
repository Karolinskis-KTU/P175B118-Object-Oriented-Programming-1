using System;
using System.Collections.Generic;

namespace Lab3.Exercises.Register
{
    class DogsRegister
    {
        private readonly DogsContainer AllDogs = new DogsContainer();

        public DogsRegister(DogsContainer Dogs)
        {
            for (int i = 0; i < Dogs.Count; i++)
            {
                this.AllDogs.Add(Dogs.Get(i));
            }
        }
        public void Add(Dog dog)
        {
            AllDogs.Add(dog);
        }
        public int DogsCount()
        {
            return this.AllDogs.Count;
        }
        public Dog GetElementByIndex(int index)
        {
            return this.AllDogs.Get(index);
        }
        public bool Contains(Dog dog)
        {
            return AllDogs.Contains(dog);
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (this.AllDogs.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public Dog FindOldestDog()
        {
            return this.FindOldestDog(this.AllDogs);
        }
        public Dog FindOldestDog(string breed)
        {
            DogsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestDog(Filtered);
        }
        private Dog FindOldestDog(DogsContainer Dogs)
        {
            Dog oldest = Dogs.Get(0); //means least value
            for (int i = 1; i < Dogs.Count; i++)
            {
                if (DateTime.Compare(Dogs.Get(i).BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Dogs.Get(i);
                }
            }
            return oldest;
        }
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                string breed = this.AllDogs.Get(i).Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public DogsContainer FilterByBreed(string breed)
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                if (this.AllDogs.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.AllDogs.Get(i));
                }
            }
            return Filtered;
        }
        // task 2
        public DogsContainer FilterByVaccination()
        {
            DogsContainer Filtered = new DogsContainer();
            for (int i = 0; i < AllDogs.Count; i++)
            {
                if (AllDogs.Get(i).RequiresVaccination == true)
                {
                    Filtered.Add(this.AllDogs.Get(i));
                }
            }
            return Filtered;
        }

        private Dog FindDogByID(int ID)
        {
            for (int i = 0; i < this.AllDogs.Count; i++)
            {
                if (this.AllDogs.Get(i).ID == ID)
                {
                    return this.AllDogs.Get(i);
                }
            }
            return null; //Returns null if dog ID not found
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Dog dog = this.FindDogByID(vaccination.DogID);
                if (dog != null) //Ignore if vaccination info doesnt correspond to any dog
                {
                    if (vaccination > dog.LastVaccinationDate)
                    {
                        dog.LastVaccinationDate = vaccination.Date;
                    }
                }

            }
        }
    }
}
