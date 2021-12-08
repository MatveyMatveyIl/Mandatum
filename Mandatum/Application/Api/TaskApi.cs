using System;
using Application.ApiInterface;

namespace Application
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
            var task = _taskRepo.GetTask(taskId);
            _taskRepo.DeleteTask(task);
        }
    }
}