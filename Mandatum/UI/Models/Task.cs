using System.Collections.Generic;

namespace Mandatum.Models
{
    public class Task
    {
        public Task(string topic)
        {
            Topic = topic;
            Status = TaskStatus.InWait;
        }

        public Task()
        {
            
        }
        
        public int Id { get; set; }
        public string Topic { get; set; }
        public TaskStatus Status { get;  set; }
    }
    public enum TaskStatus
    {
        InProgress,
        Done,
        InWait
    }
}