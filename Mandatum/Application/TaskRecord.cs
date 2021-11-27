namespace Application
{
    public class TaskRecord
    {
        public int Id { get; private set; }
        public string Topic { get; private set; }
        public TaskStatusRecord Status { get; private set; }
        public string Description { get; private set; }
        
        public TaskRecord(int id, string topic, string description, TaskStatusRecord status) //: base(id)
        {
            Id = id;
            Topic = topic;
            Description = description;
            Status = status;
        }

        public void UpdateTask(string topic, string description, TaskStatusRecord status)
        {
            Topic = topic;
            Description = description;
            Status = status;
        }
    }
}