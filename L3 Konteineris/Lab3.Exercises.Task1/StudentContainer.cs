namespace Lab3.Exercises.Task1
{
    class StudentContainer
    {
        public string Name;    // Faculty Name
        private Student[] Students;
        private int Capacity;
        public int Count { get; private set; }
        /// <summary>
        /// Creates a container with all students in a faculty
        /// </summary>
        /// <param name="capacity">Optional to set a different capacity</param>
        public StudentContainer(int capacity = 16) //default capacity
        {
            this.Students = new Student[capacity];
        }
        /// <summary>
        /// Adds data to existing <paramref name="container"/>
        /// </summary>
        /// <param name="container">Existing container</param>
        public StudentContainer(StudentContainer container) : this()
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        /// <summary>
        /// Adds a <paramref name="student"/> to container
        /// </summary>
        /// <param name="student">Student data</param>
        public void Add(Student student)
        {
            if (this.Count == this.Capacity) // if container is full
            {
                EnsureCapacity(this.Capacity + 1);
            }
            this.Students[this.Count++] = student;
        }
        /// <summary>
        /// If needed adds more capacity to student array
        /// </summary>
        /// <param name="minimumCapacity">minimum capacity of student array</param>
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Student[] temp = new Student[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.Students[i];
                }
                this.Capacity = minimumCapacity;
                this.Students = temp;
            }
        }
        /// <summary>
        /// Gets student data from container
        /// </summary>
        /// <param name="index">Index of student data</param>
        /// <returns></returns>
        public Student Get(int index)
        {
            return this.Students[index];
        }
        /// <summary>
        /// Checks if container has a certain student
        /// </summary>
        /// <param name="student">Student data to search for</param>
        /// <returns></returns>
        public bool Contains(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Students[i].Equals(student))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds element to a container in a certain place 
        /// </summary>
        /// <param name="student">Data to be added</param>
        /// <param name="index">place to add to</param>
        public void Put(Student student, int index)
        {
            this.Students[index] = student;
        }
        /// <summary>
        /// Inserts element to a container in a certain place
        /// </summary>
        /// <param name="student">Data to be inserted</param>
        /// <param name="index">place to insert to</param>
        public void Insert(Student student, int index)
        {
            for (int i = this.Capacity; i >= index; i--)
            {
                this.Students[i + 1] = this.Students[i];
            }
            this.Students[index] = student;
        }
        /// <summary>
        /// Remove element that is same as <paramref name="student"/>
        /// </summary>
        /// <param name="student">student element to remove</param>
        public void Remove(Student student)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Students[i] == student)
                {
                    for (int j = i; j < this.Count; j++)
                    {
                        this.Students[j] = this.Students[j + 1];
                    }
                    this.Count--;
                    break;
                }
            }
        }
        /// <summary>
        /// Remove element at a certain <paramref name="index"/>
        /// </summary>
        /// <param name="index">element index</param>
        public void RemoveAt(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.Students[i] = this.Students[i + 1];
            }
            this.Count--;
        }
    }
}
