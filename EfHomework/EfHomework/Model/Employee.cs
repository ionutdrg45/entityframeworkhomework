using System.Collections.Generic;

namespace EfHomework.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Task> Tasks { get; set; } = new List<Task>();
    }
}
