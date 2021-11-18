using System;

namespace Domain
{
    public class TaskManager
    {
        private ITaskRepo repo { get; set; }
        public TaskManager(ITaskRepo rep)
        {
            repo = rep;
        }

        public void AddTask(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}