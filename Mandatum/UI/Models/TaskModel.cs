using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mandatum.Models
{
    public class TaskModel
    { 
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "Укажите заголовок")]
        public string Topic { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public string Executors { get; set; }
        [DataType(DataType.DateTime )]
        public DateTime Deadline { get; set; }
    }
    
    public enum TaskStatus
    {
        InProgress,
        Done,
        InWait
    }
}