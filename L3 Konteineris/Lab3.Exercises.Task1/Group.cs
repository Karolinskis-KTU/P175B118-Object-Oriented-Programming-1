namespace Lab3.Exercises.Task1
{
    class Group
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Average grade of group
        /// </summary>
        public double AverageGrade { get; set; }
        /// <summary>
        /// How many grades group has
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Constructor of group
        /// </summary>
        /// <param name="groupName"></param>
        public Group(string groupName)
        {
            this.Name = groupName;
            this.AverageGrade = 0;
            this.Count = 1;
        }
        /// <summary>
        /// Compare by average grade and name
        /// </summary>
        /// <param name="other">group to compare to</param>
        /// <returns></returns>
        public int CompareTo(Group other)
        {
            if (this.AverageGrade == other.AverageGrade)
            {
                return this.Name.CompareTo(other.Name);
            }
            return other.AverageGrade.CompareTo(this.AverageGrade);
        }
    }
}
