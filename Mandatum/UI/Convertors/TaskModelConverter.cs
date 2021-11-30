using Application;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class TaskModelConverter: IConvertor<TaskRecord, TaskModel>
    {
        public TaskRecord Convert(TaskModel source)
        {
            return new TaskRecord()
            {
                Description = source.Description,
                Status = source.Status,
                Term = source.Term,
                Topic = source.Topic,
            };
        }

        public TaskModel Convert(TaskRecord source)
        {
            throw new System.NotImplementedException();
        }
    }
}