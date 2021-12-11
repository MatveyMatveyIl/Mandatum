using System;

namespace Mandatum.Models
{
    public class TaskViewModel
    {
        public Guid BoardId { get; }
        public TaskModel TaskModel { get; }
        public string Method { get; }

        public TaskViewModel(Guid boardId, TaskModel taskModel, string method)
        {
            BoardId = boardId;
            TaskModel = taskModel;
            Method = method;
        }
    }
}