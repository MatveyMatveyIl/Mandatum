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

        public void UpdateTask(TaskRecord updTask)
        {
        }

        public void DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }
    }
}