using System.Collections.Generic;
using System.Linq;

namespace Mandatum.Models
{
    public class TaskRepo : ITaskRepo
    {
        public IQueryable<Task> Tasks { get; }
        public void AddTask(Task task)
        {
            if (task.Topic != null)
                Tasks.Append(task);
        }

        public Task GetTask(int id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetInitialElements()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetAllSubTasks(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeStatus(int taskId, TaskStatus status)
        {
            throw new System.NotImplementedException();
        }
    }
}