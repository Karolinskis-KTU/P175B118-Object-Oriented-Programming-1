using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Exercises.Task1
{
    static class TaskUtils
    {
        public static double CalculateCollectedMoney(List<Person> People)
        {
            int sum = 0;
            foreach (Person person in People)
            {
                sum += person.ConvertToCents()/4;
            }


            return sum;
        }

        public static List<Person> FilterByDonation(List<Person> People)
        {
            List<Person> Filtered = new List<Person>();
            //Finding the highest donation
            int highestDonation = 0;
            foreach (Person person in People)
            {
                if (highestDonation < person.ConvertToCents()/4)
                {
                    highestDonation = person.ConvertToCents()/4;
                }
            }
            //Searching for all people with the highest donation
            foreach (Person person in People)
            {
                if (person.ConvertToCents()/4 == highestDonation)
                {
                    person.Euro = ((person.Euro * 100 + person.Cents) / 4) / 100;
                    person.Cents = ((person.Euro * 100 + person.Cents) / 4) % 100;
                    Filtered.Add(person);
         
                }
            }

            return Filtered;
        }
    }
}
