using System;

namespace Application
{
    public class TaskRecord
    {
        public int Id { get;  set; }
        public string Topic { get;  set; }
        public TaskStatusRecord Status { get;  set; }
        public string Description { get;  set; }

        public DateTime term { get;  set; }
    }
}