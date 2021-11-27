using System;

namespace Application
{
    public class TaskRecord
    {
        public int Id { get; private set; }
        public string Topic { get; private set; }
        public TaskStatusRecord Status { get; private set; }
        public string Description { get; private set; }

        public DateTime term { get; private set; }
    }
}