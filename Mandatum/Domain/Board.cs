using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddTask(Task task, string email)
        {
            task.RefreshToValidTask(email);
            if (CountTasksInProgress() <= 10 && task.Status == TaskStatus.InProgress)
            {
                Tasks.Add(task);
            }

            if (task.Status != TaskStatus.InProgress)
            {
                Tasks.Add(task);
            }
        }

        private int CountTasksInProgress()
        {
            return Tasks.Count(t => t.Status == TaskStatus.InProgress);
        }
    }
}