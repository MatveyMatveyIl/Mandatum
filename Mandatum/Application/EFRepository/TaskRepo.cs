using System;
using System.Collections.Generic;
using System.Linq;
using Mandatum.Models;
using Microsoft.EntityFrameworkCore;

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
            if (Tasks.Any(taskRecord => taskRecord.Id == task.Id))
                db.Update(task);
            else
                db.Add(task);
            db.SaveChanges();
        }

        public IEnumerable<TaskRecord> GetTasks(Guid boardId)
        {
            var board = db.Boards.FirstOrDefault(b => b.Id == boardId);
            return board.TaskIds;
        }

        public TaskRecord GetTask(Guid id)
        {
            var task =  Tasks.FirstOrDefault(taskRecord => taskRecord.Id == id);
            return task;
        }

        public TaskRecord GetTask(TaskRecord taskRecord)
        {
            return Tasks.FirstOrDefault(record => record.Equals(taskRecord));
        }

        public void UpdateTask(TaskRecord newTask)
        {
            db.Update(newTask);
            db.SaveChanges();
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