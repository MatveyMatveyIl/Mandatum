using System;
using Application.Entities;

namespace Application.RepositoryInterface
{
    public interface ITaskRepo
    {
        public void AddTask(TaskRecord task);
        public void DeleteTask(TaskRecord task);
        public void UpdateTask(TaskRecord updTask);
        public TaskRecord GetTask(Guid id);
    }
}