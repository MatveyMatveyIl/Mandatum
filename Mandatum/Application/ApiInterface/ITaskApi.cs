using System;
using Application.Entities;

namespace Application.ApiInterface
{
    public interface ITaskApi
    {
        public void SaveTask(TaskRecord task);
        public void UpdateTask(TaskRecord updTask);
        public void DeleteTask(Guid taskId);
        public TaskRecord GetTask(Guid id);
    }
}