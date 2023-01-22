using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Exercises.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> allPeople = InOutUtils.ReadPeople(@"People.csv");
            Console.WriteLine("Turistines grupes nariai:");
            InOutUtils.PrintPeople(allPeople);

            Console.WriteLine("Is viso surinkta pinigu bendroms grupes islaidoms: {0} eurai", TaskUtils.CalculateCollectedMoney(allPeople) / 100);
            Console.WriteLine();

            Console.WriteLine("Grupes nariai skyre daugiausiai pinigu grupes islaidoms");
            List<Person> FilteredByDonation = TaskUtils.FilterByDonation(allPeople);
            InOutUtils.PrintPeople(FilteredByDonation);

            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
