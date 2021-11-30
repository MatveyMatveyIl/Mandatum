using System;
using System.Collections.Generic;

namespace Mandatum.Models
{
    public class TaskModel
    { 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get;  set; }
        
        public string Description { get; set; }
        public List<string> Executors { get; set; }
        public int Priority { get; set; }
        public DateTime Deadline { get; set; }
    }
    
    public enum TaskStatus
    {
        InProgress,
        Done,
        InWait
    }
}