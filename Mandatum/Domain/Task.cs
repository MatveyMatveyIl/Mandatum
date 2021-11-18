using System;

namespace Domain
{
    public class Task: Entity<int>
    {
        public int Id { get; private set; }
        public string Topic { get; private set; }
        public TaskStatus Status { get; private set; }
        public string Description { get; private set; }
        
        public Task(int id, string topic, string description, TaskStatus status) : base(id)
        {
            Id = id;
            Topic = topic;
            Description = description;
            Status = status;
        }

        public void UpdateTask(string topic, string description, TaskStatus status)
        {
            Topic = topic;
            Description = description;
            Status = status;
        }
    }
}