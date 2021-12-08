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

        public IQueryable<TaskRecord> Tasks => _dbContext.Tasks;

        public void AddTask(TaskRecord task)
        {
            if (Tasks.Any(taskRecord => taskRecord.Id == task.Id))
                _dbContext.Update(task);
            else
                _dbContext.Add(task);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TaskRecord> GetTasks(Guid boardId)
        {
            var board = _dbContext.Boards.FirstOrDefault(b => b.Id == boardId);
            return board.TaskIds;
        }

        public TaskRecord GetTask(Guid id)
        {
            return Tasks.FirstOrDefault(taskRecord => taskRecord.Id == id);
        }

        public TaskRecord GetTask(TaskRecord taskRecord)
        {
            return Tasks.FirstOrDefault(record => record.Equals(taskRecord));
        }

        public void UpdateTask(TaskRecord newTask)
        {
            _dbContext.Update(newTask);
            _dbContext.SaveChanges();
        }

        public void DeleteTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRecord> GetInitialElements()
        {
            return Tasks;
        }

        public IEnumerable<TaskRecord> GetAllSubTasks(int id)
        {
            throw new NotImplementedException();
        }

        public void ChangeStatus(int taskId, TaskStatusRecord status)
        {
            throw new NotImplementedException();
        }
    }
}