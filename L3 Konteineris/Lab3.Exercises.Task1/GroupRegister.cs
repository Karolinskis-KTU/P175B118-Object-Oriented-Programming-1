using System;

namespace Lab3.Exercises.Task1
{
    class GroupRegister
    {
        private readonly GroupContainer allGroups = new GroupContainer();
        /// <summary>
        /// Adds data to group register with <paramref name="groups"/> data
        /// </summary>
        /// <param name="groups"></param>
        public GroupRegister (GroupContainer groups)
        {
            allGroups = groups;
        }

        /// <summary>
        /// Calculates the average grade for every group
        /// </summary>
        /// <param name="students"> Students data for getting average grades</param>
        public void AverageSum(StudentContainer students)
        {
            for (int i = 0; i < allGroups.Count; i++)
            {
                for (int y = 0; y < students.Count; y++)
                {
                    Group group = allGroups.Get(i);
                    Student student = students.Get(y);
                    if (group.Name == student.Group) //Groupcontainer name is same as student group
                    {
                        group.AverageGrade += student.AverageGrade;
                    }
                }
                allGroups.Get(i).AverageGrade = Math.Round((allGroups.Get(i).AverageGrade / allGroups.Get(i).Count), 2);
            }
        }
    }
}
