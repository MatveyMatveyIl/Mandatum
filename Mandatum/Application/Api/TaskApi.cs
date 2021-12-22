using System;
using Application.ApiInterface;
using Application.Entities;
using Application.RepositoryInterface;

namespace Application.Api
{
    public class TaskApi : ITaskApi
    {
        private readonly ITaskRepo _taskRepo;

        public TaskApi(ITaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public void SaveTask(TaskRecord task)
        {
            _taskRepo.AddTask(task);
        }

        public TaskRecord GetTask(Guid id)
        {
           return _taskRepo.GetTask(id);
        }

        public void UpdateTask(TaskRecord updTask)
        {
            _taskRepo.UpdateTask(updTask);
        }

        public void DeleteTask(Guid taskId)
        {
            if(GetTask(taskId) is null) return;
            var task = _taskRepo.GetTask(taskId);
            _taskRepo.DeleteTask(task);
        }
    }
}