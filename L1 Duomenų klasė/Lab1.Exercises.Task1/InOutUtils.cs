using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Lab1.Exercises.Task1
{
    class InOutUtils
    {
        public static List<Person> ReadPeople(string fileName)
        {
            List<Person> People = new List<Person>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string surname = Values[1];
                int euro = int.Parse(Values[2]);
                int cents = int.Parse(Values[3]);

                Person person = new Person(name, surname, euro, cents);
                People.Add(person);
            }

            return People;
        }

        public static void PrintPeople(List<Person> People)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-4} {3,-4}", "Vardas", "Pavarde", "Eurai", "Centai");
            Console.WriteLine(new string('-', 65));
            foreach (Person person in People)
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-4} {3,-4}", person.Name, person.Surname, person.Euro, person.Cents);

            }
            Console.WriteLine(new string('-', 65));
        }
    }
}
