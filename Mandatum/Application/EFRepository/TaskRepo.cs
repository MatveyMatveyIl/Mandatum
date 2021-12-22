using System;
using System.Linq;
using Application.DbContext;
using Application.Entities;
using Application.RepositoryInterface;

namespace Application.EFRepository
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
            _dbContext.Add(task);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(TaskRecord task)
        {
            if (GetTask(task.Id) is null) return;
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        public void UpdateTask(TaskRecord updTask)
        {
            try
            {
                if (GetTask(updTask.Id) is null) return;
                _dbContext.Tasks.Update(updTask);
                _dbContext.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                _dbContext.SaveChanges();
            }
        }

        public TaskRecord GetTask(Guid id)
        {
            return _dbContext.Tasks.FirstOrDefault(task => task.Id == id);
        }
    }
}