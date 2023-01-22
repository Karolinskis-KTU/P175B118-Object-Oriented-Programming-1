using System;
using System.Text;

namespace Lab3.Exercises.Task1
{
    class GroupContainer
    {
        private Group[] Groups;
        private int Capacity;
        /// <summary>
        /// Shows how many groups are in the container
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Creates a new group for container
        /// </summary>
        /// <param name="capacity"></param>
        public GroupContainer(int capacity = 16)
        {
            this.Groups = new Group[capacity];
        }
        /// <summary>
        /// Adds data to container
        /// </summary>
        /// <param name="container">Container data to add</param>
        public GroupContainer(GroupContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        /// <summary>
        /// Adds group to container
        /// </summary>
        /// <param name="group">group to add</param>
        public void Add(Group group)
        {
            if (this.Count == this.Capacity) // if container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            this.Groups[this.Count++] = group;
        }
        /// <summary>
        /// Check if <paramref name="name"/> group is in group container
        /// </summary>
        /// <param name="name">group name</param>
        /// <returns></returns>
        public bool HasGroup(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Groups[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// If needed adds more capacity to group array
        /// </summary>
        /// <param name="minimumCapacity">minimum capacity of group array</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Group[] temp = new Group[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Groups[i];
                }
                this.Capacity = minimumCapacity;
                this.Groups = temp;
            }
        }
        /// <summary>
        /// Gets a certain group by <paramref name="name"/>
        /// </summary>
        /// <param name="name">group name</param>
        /// <returns></returns>
        public Group GetGroup(string name)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (name == this.Groups[i].Name)
                {
                    return this.Groups[i];
                }
            }
            return null;
        }
        /// <summary>
        /// Adds group name from <paramref name="students"/> student container
        /// </summary>
        /// <param name="students">Container of students to try to add</param>
        public void Add(StudentContainer students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Add(students.Get(i).Group);
            }
        }

        /// <summary>
        /// Adds group name to container if it doesnt exist in current context
        /// </summary>
        /// <param name="name">group name to add</param>
        public void Add(string name)
        {
            if (this.Count == this.Capacity) // if container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            if (!HasGroup(name))
            {
                this.Groups[this.Count++] = new Group(name);
            }
            else
            {
                Group group = GetGroup(name);
                group.Count++;
            }
        }



        /// <summary>
        /// Gets data for a certain group with an <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to get by</param>
        /// <returns></returns>
        public Group Get(int index)
        {
            return this.Groups[index];
        }
        /// <summary>
        /// Puts data in a certain place in group array
        /// </summary>
        /// <param name="group">Group data to add</param>
        /// <param name="index">Index to put to</param>
        public void Put(Group group, int index) 
        {
            this.Groups[index] = group;
        }
        /// <summary>
        /// Inserts group data to <paramref name="index"/>
        /// </summary>
        /// <param name="group">Group data to add</param>
        /// <param name="index">Index to insert to</param>
        public void Insert(Group group, int index)
        {
            for (int i = this.Count; i < index; i--)
            {
                this.Groups[i] = this.Groups[i - 1];
            }
            this.Count++;
            this.Groups[index] = group;
        }
        /// <summary>
        /// Removes data by <paramref name="group"/> data
        /// </summary>
        /// <param name="group">Group to remove</param>
        public void Remove(Group group)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Groups[i].Name == group.Name)
                {
                    RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Removes data by <paramref name="index"/>
        /// </summary>
        /// <param name="index">Index to remove at</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.Groups[i] = this.Groups[i + 1];
            }
            this.Count--;
        }
        /// <summary>
        /// Checks if group container has <paramref name="group"/> data
        /// </summary>
        /// <param name="group">Group data to check for</param>
        /// <returns>Returns true if container contains <paramref name="group"/></returns>
        public bool Contains(Group group)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Groups[i].Equals(group))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sorts group container by average grade
        /// </summary>
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Group a = Groups[i];
                    Group b = Groups[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.Groups[i] = b;
                        this.Groups[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

    }
}
