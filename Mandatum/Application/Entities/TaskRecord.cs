using System;
using System.Collections.Generic;

namespace Application
{
    public class TaskRecord
    {
        public Guid Id { get; set; }
        public string Topic { get; set; }
        public TaskStatusRecord Status { get; set; }
        public string Description { get; set; }

        public DateTime Term { get; set; }
        
        
        
    }
}