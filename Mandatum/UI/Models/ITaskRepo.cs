using System.Collections.Generic;
using System.Linq;

namespace Mandatum.Models
{
    public interface ITaskRepo
    {
        public IQueryable<Task> Tasks { get; }
        public void AddTask(Task task);
        public Task GetTask(int id);
        public void DeleteTask(int id);
        public IEnumerable<Task> GetAll();
        public IEnumerable<Task> GetInitialElements();
        public IEnumerable<Task> GetAllSubTasks(int id);
        public void ChangeStatus(int taskId, TaskStatus status);
    }
}