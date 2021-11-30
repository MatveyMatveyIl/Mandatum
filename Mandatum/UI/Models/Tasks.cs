using System.Collections.Generic;

namespace Mandatum.Models
{
    public class Tasks
    {
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