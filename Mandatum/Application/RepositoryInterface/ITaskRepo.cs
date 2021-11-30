using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public interface ITaskRepo
    {
        public IQueryable<TaskRecord> Tasks { get; }
        public void AddTask(TaskRecord task);
        public TaskRecord GetTask(Guid id);
        public void DeleteTask(Guid id);
        public IEnumerable<TaskRecord> GetAll();
        public IEnumerable<TaskRecord> GetInitialElements();
        public IEnumerable<TaskRecord> GetAllSubTasks(int id);
        public void ChangeStatus(int taskId, TaskStatusRecord status);
    }
}