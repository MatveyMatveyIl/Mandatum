using System;
using System.Collections.Generic;
using System.Linq;

namespace Mandatum.Models
{
    public class KanbanColumnModel
    {
        public Guid BoardId;
        public Dictionary<TaskStatus, string> Labels;
        public Dictionary<TaskStatus, IEnumerable<TaskModel>> Tasks;

        public KanbanColumnModel(Guid boardId, IEnumerable<TaskModel> tasks)
        {
            BoardId = boardId;
            Tasks = new Dictionary<TaskStatus, IEnumerable<TaskModel>>
            {
                [TaskStatus.InWait] = tasks.Where(task => task.Status == TaskStatus.InWait),
                [TaskStatus.InProgress] = tasks.Where(task => task.Status == TaskStatus.InProgress),
                [TaskStatus.Done] = tasks.Where(task => task.Status == TaskStatus.Done)
            };
            
            Labels = new Dictionary<TaskStatus, string>
            {
                [TaskStatus.InWait] = "Не начато",
                [TaskStatus.InProgress] = "В процессе",
                [TaskStatus.Done] = "Готово"
            };

        }
    }
}