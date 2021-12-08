using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public interface ITaskRepo
    {
        public void AddTask(TaskRecord task);
        public void DeleteTask(TaskRecord task);
        public void UpdateTask(TaskRecord updTask);
        public TaskRecord GetTask(Guid id);
    }
}