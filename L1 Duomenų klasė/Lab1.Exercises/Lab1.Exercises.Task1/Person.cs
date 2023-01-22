using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Exercises.Task1
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Euro { get; set; }
        public int Cents { get; set; }

        public Person(string name, string surname, int euro, int cents)
        {
            this.Name = name;
            this.Surname = surname;
            this.Euro = euro;
            this.Cents = cents;
        }

        public int ConvertToCents()
        {
            int centsConverted = this.Euro * 100 + this.Cents;

            return centsConverted;
        }
    }
}
