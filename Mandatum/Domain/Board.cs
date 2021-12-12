using System;
using System.Collections.Generic;

namespace Domain
{
    public enum BoardFormatDomain
    {
        KanbanBoard,
        Graph,
        Table
    }
    
    public class Board
    {
        public Guid Id { get; set; }
        public virtual List<Task> Tasks { get; set; } = new List<Task>();
        public bool Privacy { get; set; }
        public BoardFormatDomain Format { get; set; }
        public string Name { get; set; }

        public void AddTask(Task task)
        {
            Tasks.Add(task);
        }
    }
}