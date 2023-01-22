using System;

namespace Lab3.Exercises.Task1
{
    class Student
    {
        /// <summary>
        /// Students surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Students name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Students study group
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Ammount of graes stuent has got
        /// </summary>
        public int GradeCount { get; set; }
        /// <summary>
        /// Grades array
        /// </summary>
        public int[] Grades { get; set; }

        /// <summary>
        /// Constructor of student
        /// </summary>
        /// <param name="surname">students surname</param>
        /// <param name="name">Students name</param>
        /// <param name="group">Students study group</param>
        /// <param name="gradeCount">Ammount of graes stuent has got</param>
        /// <param name="grades">Grades array</param>
        public Student(string surname, string name, string group, int gradeCount, int[] grades)
        {
            this.Surname = surname;
            this.Name = name;
            this.Group = group;
            this.GradeCount = gradeCount;
            this.Grades = grades;
        }
        /// <summary>
        /// Calculate average of a student
        /// </summary>
        public double AverageGrade
        {
            get
            {
                double average = 0;
                for (int i = 0; i < GradeCount; i++)
                {
                    average += this.Grades[i];
                }
                return Math.Round((average / this.GradeCount), 2);
            }
        }
    }
}
