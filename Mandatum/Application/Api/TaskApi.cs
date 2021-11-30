using System;
using System.Collections.Generic;

namespace Application
{
    public class TaskApi
    {
        private readonly TaskRepo _taskRepo;

        public TaskApi(TaskRepo taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public IEnumerable<TaskRecord> GetTasks()
        {
            return _taskRepo.Tasks;
        }

        public TaskRecord GetTask(Guid id)
        {
            return _taskRepo.GetTask(id);
        }
    }
}