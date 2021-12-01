using System;
using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public Guid Id { get; set; }
        public virtual List<TaskRecord> TaskIds { get; set; }
        public bool Privacy { get; set; }
        public BoardFormat Format { get; set; }
    }

    public enum BoardFormat
    {
        KanbanBoard,
        Graph
    }
}