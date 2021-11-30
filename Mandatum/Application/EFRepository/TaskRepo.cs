using System;
using System.Collections.Generic;
using System.Linq;
using Mandatum.Models;

namespace Application
{
    public class TaskRepo : ITaskRepo
    {
        private readonly AppDbContext db;

        public TaskRepo(AppDbContext db)
        {
            this.db = db;
        }

        public IQueryable<TaskRecord> Tasks => db.Tasks;
        
        public void AddTask(TaskRecord task)
        {
            db.Add(task);
            db.SaveChanges();
        }

        public TaskRecord GetTask(Guid id)
        {
            return Tasks.FirstOrDefault(taskRecord => taskRecord.Id == id);
        }

        public void DeleteTask(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TaskRecord> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TaskRecord> GetInitialElements()
        {
            return Tasks;
        }

        public IEnumerable<TaskRecord> GetAllSubTasks(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeStatus(int taskId, TaskStatusRecord status)
        {
            throw new System.NotImplementedException();
        }
    }
}