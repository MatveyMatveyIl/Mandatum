using System;
using System.Collections.Generic;

namespace Application
{
    public class TaskRecord
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatusRecord Status { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
        public string Executors { get; set; }
    }
}