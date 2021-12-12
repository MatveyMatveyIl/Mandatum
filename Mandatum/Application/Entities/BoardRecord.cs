using System;
using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public Guid Id { get; set; }
        public virtual List<TaskRecord> TaskIds { get; set; } = new List<TaskRecord>();
        public virtual List<UserRecord> Users { get; set; } = new List<UserRecord>();
        public bool Privacy { get; set; }
        public BoardFormat Format { get; set; }
        public string Name { get; set; }
    }

    public enum BoardFormat
    {
        KanbanBoard,
        Table
    }
}