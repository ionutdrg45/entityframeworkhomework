using System;
using System.Collections.Generic;

namespace EfHomework.Model
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsSpecial { get; set; }
        public double Price { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
        public int ProjectId { get; set; }
    }
}
