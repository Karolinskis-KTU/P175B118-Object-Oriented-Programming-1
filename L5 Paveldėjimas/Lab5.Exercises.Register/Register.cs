using System;
using System.Collections.Generic;

namespace Lab5.Exercises.Register
{
    class Register
    {
        private readonly AnimalsContainer AllAnimals = new AnimalsContainer();

        public Register(AnimalsContainer Animals)
        {
            for (int i = 0; i < Animals.Count; i++)
            {
                this.AllAnimals.Add(Animals.Get(i));
            }
        }
        public void Add(Animal animal)
        {
            AllAnimals.Add(animal);
        }
        public int AnimalsCount ()
        {
            return this.AllAnimals.Count;
        }
        public Animal GetElementByIndex(int index)
        {
            return this.AllAnimals.Get(index);
        }
        public bool Contains(Animal animal)
        {
            return AllAnimals.Contains(animal);
        }
        public int CountByGender(Gender gender)
        {
            int count = 0;
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (this.AllAnimals.Get(i).Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }
        public Animal FindOldestAnimal()
        {
            return this.FindOldestAnimal(this.AllAnimals);
        }
        public Animal FindOldestAnimal(string breed)
        {
            AnimalsContainer Filtered = this.FilterByBreed(breed);
            return this.FindOldestAnimal(Filtered);
        }
        private Animal FindOldestAnimal(AnimalsContainer Animals)
        {
            Animal oldest = Animals.Get(0); //means least value
            for (int i = 1; i < Animals.Count; i++)
            {
                if (DateTime.Compare(Animals.Get(i).BirthDate, oldest.BirthDate) < 0)
                {
                    oldest = Animals.Get(i);
                }
            }
            return oldest;
        }
        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                string breed = this.AllAnimals.Get(i).Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }
        public AnimalsContainer FilterByBreed(string breed)
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                if (this.AllAnimals.Get(i).Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(this.AllAnimals.Get(i));
                }
            }
            return Filtered;
        }

        public AnimalsContainer FilterByVaccination()
        {
            AnimalsContainer Filtered = new AnimalsContainer();
            for (int i = 0; i < AllAnimals.Count; i++)
            {
                if (AllAnimals.Get(i).RequiresVaccination == true)
                {
                    Filtered.Add(this.AllAnimals.Get(i));
                }
            }
            return Filtered;
        }

        private Animal FindAnimalByID(int ID)
        {
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                if (this.AllAnimals.Get(i).ID == ID)
                {
                    return this.AllAnimals.Get(i);
                }
            }
            return null; //Returns null if dog ID not found
        }
        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindAnimalByID(vaccination.AnimalID);
                if (animal != null) //Ignore if vaccination info doesnt correspond to any dog
                {
                    if (vaccination > animal.LastVaccinationDate)
                    {
                        animal.LastVaccinationDate = vaccination.Date;
                    }
                }

            }
        }

        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal animal = this.AllAnimals.Get(i);
                if (animal is Dog && (animal as Dog).Agressive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
