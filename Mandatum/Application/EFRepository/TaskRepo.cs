using System;
using System.Collections.Generic;
using System.Linq;
using Mandatum.Models;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _dbContext.Add(task);
                _dbContext.SaveChanges();
            }
            catch
            {
                //
            }
        }

        public void DeleteTask(TaskRecord task)
        {
            try
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
            }
            catch
            {
                //
            }
        }

        public void UpdateTask(TaskRecord updTask)
        {
            try
            {
                _dbContext.Tasks.Update(updTask);
                _dbContext.SaveChanges();
            }
            catch 
            {
                //
            }
            
        }

        public TaskRecord GetTask(Guid id)
        {
            try
            {
                return _dbContext.Tasks.FirstOrDefault(task => task.Id == id);
            }
            catch
            {
                return new TaskRecord();
            }
        }
    }
}