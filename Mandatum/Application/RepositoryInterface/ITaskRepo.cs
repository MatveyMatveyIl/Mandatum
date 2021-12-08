using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public interface ITaskRepo
    {
        public void AddTask(TaskRecord task);
        public void DeleteTask(Guid taskId);
        public void UpdateTask(TaskRecord updTask);
    }
}