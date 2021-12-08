using System;
using System.Collections.Generic;
using System.Linq;
using Mandatum.Models;

namespace Application
{
    public class TaskRepo : ITaskRepo
    {
        private readonly AppDbContext _dbContext;

        public TaskRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void AddTask(TaskRecord task)
        {
            if (_dbContext.Tasks.Any(taskRecord => taskRecord.Id == task.Id))
                _dbContext.Update(task);
            else
                _dbContext.Add(task);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(TaskRecord updTask)
        {
            throw new NotImplementedException();
        }

        public TaskRecord GetTask(Guid id)
        {
            return _dbContext.Tasks.FirstOrDefault(task => task.Id == id);
        }
    }
}