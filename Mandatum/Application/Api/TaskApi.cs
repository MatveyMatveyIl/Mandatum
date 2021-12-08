using System;
using Application.ApiInterface;

namespace Application
{
    public class TaskApi : ITaskApi
    {
        private readonly TaskRepo _taskRepo;

        public TaskApi(TaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public void SaveTask(TaskRecord task)
        {
            _taskRepo.AddTask(task);
        }

        public void UpdateTask(TaskRecord updTask)
        {
        }

        public void DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}