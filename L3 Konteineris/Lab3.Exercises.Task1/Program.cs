using System;

namespace Lab3.Exercises.Task1
{
    class Program
    {
        const string fileRead = "fakultetas.csv";
        static void Main()
        {
            StudentContainer allStudents = InOutUtils.ReadFaculty(fileRead);
            InOutUtils.PrintFaculty("Pradiniai fakulteto duomenys", allStudents);

            GroupContainer allGroups = new GroupContainer();
            allGroups.Add(allStudents);

            GroupRegister groups = new GroupRegister(allGroups);
            InOutUtils.PrintGroups("Grupių sąrašas mažėjančia tvarka pagal vidurki", allGroups);
            groups.AverageSum(allStudents);
            InOutUtils.PrintGroups("Grupių sąrašas mažėjančia tvarka pagal vidurki", allGroups);
            allGroups.Sort();
            InOutUtils.PrintGroups("Grupių sąrašas mažėjančia tvarka pagal vidurki", allGroups);


            Console.ReadKey(); //Pause program
        }
    }
}
