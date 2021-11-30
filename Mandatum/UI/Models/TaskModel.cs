using System;
using System.Collections.Generic;

namespace Mandatum.Models
{
    public class TaskModel
    { 
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }

        public DateTime Term { get; set; }
    }
    
    public enum TaskStatus
    {
        InProgress,
        Done,
        InWait
    }
}