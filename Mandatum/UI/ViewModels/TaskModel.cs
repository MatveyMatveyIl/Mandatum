using System;

namespace Mandatum.ViewModels
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public TaskStatusModel Status { get; set; }
        public string Description { get; set; }

        public DateTime Term { get; set; }
    }

    public enum TaskStatusModel
    {
        InProgress,
        Done,
        InWait
    }
}