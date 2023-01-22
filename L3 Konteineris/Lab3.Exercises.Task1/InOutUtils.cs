using System;
using System.Text;

using System.IO; // For reading from files

namespace Lab3.Exercises.Task1
{
    class InOutUtils
    {
        /// <summary>
        /// Reads faculty data from <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">Filename of data file</param>
        /// <returns></returns>
        public static StudentContainer ReadFaculty (string fileName)
        {
            StudentContainer faculty = new StudentContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            faculty.Name = Lines[0];
            for (int i = 1; i < Lines.Length; i++)
            {
                string[] Values = Lines[i].Split(';');
                string surname = Values[0];
                string name = Values[1];
                string group = Values[2];
                int gradeCount = int.Parse(Values[3]);
                int[] grades = new int[gradeCount]; //grades array declaration
                for (int j = 0; j < gradeCount; j++)
                {
                    grades[j] = int.Parse(Values[j + 4]);
                }
                Student student = new Student(surname, name, group, gradeCount, grades);
                faculty.Add(student);
            }
            return faculty;
        }
        /// <summary>
        /// Prints faculty data with a <paramref name="label"/>
        /// </summary>
        /// <param name="label">Label for faculty table</param>
        /// <param name="Faculty">Faculty data to print</param>
        public static void PrintFaculty(string label, StudentContainer Faculty)
        {
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("| {0,-74} |", label);
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("| {0, -74} |", Faculty.Name);// Faculty name
            Console.WriteLine(new string('-', 78));
            Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} | {3,-20} |", "Pavardė", "Vardas", "Grupė", "Pazymiai");
            Console.WriteLine(new string('-', 78));
            for (int i = 0; i < Faculty.Count; i++)
            {
                Student student = Faculty.Get(i);
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-15} | {3,20} |", student.Surname, student.Name, student.Group, String.Join(" ", student.Grades));
            }
            Console.WriteLine(new string('-', 78));
        }
        /// <summary>
        /// Prints group average grade with a <paramref name="label"/>
        /// </summary>
        /// <param name="label">Label for group table</param>
        /// <param name="groups">Group data to print</param>
        public static void PrintGroups(string label, GroupContainer groups)
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("| {0,-33} |", label);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("| {0,-22} | {1,-21} |", "Grupė", "Vidurkis");
            Console.WriteLine(new string('-', 50));
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine("| {0,-22} | {1,21} |", groups.Get(i).Name, groups.Get(i).AverageGrade);
            }
            Console.WriteLine(new string('-', 50));
        }
    }
}
