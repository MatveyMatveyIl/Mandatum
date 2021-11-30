using System;
using System.Collections.Generic;
using System.Linq;

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
            return _taskRepo.Tasks.ToList();
        }

        public TaskRecord GetTask(Guid id)
        {
            return _taskRepo.GetTask(id);
        }

        public TaskRecord GetTask(TaskRecord taskRecord)
        {
            return _taskRepo.GetTask(taskRecord);
        }

        public void AddTask(TaskRecord task)
        {
            _taskRepo.AddTask(task);
        }
    }
}