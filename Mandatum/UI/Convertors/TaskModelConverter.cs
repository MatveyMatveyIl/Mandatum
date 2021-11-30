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
                Status = ConvertToTaskRecordStatus(source.Status),
                Term = source.Term,
                Topic = source.Topic,
            };
        }

        private TaskStatusRecord ConvertToTaskRecordStatus(TaskStatusModel statusRecord)
        {
            return statusRecord switch
            {
                TaskStatusModel.Done => TaskStatusRecord.Done,
                TaskStatusModel.InProgress => TaskStatusRecord.InProgress,
                TaskStatusModel.InWait => TaskStatusRecord.InWait
            };
        }
        
        private TaskStatusModel ConvertToTaskModelStatus(TaskStatusRecord statusRecord)
        {
            return statusRecord switch
            {
                TaskStatusRecord.Done => TaskStatusModel.Done,
                TaskStatusRecord.InProgress => TaskStatusModel.InProgress,
                TaskStatusRecord.InWait => TaskStatusModel.InWait
            };
        }

        public TaskModel Convert(TaskRecord source)
        {
            return new TaskModel()
            {
                Description = source.Description,
                Status = ConvertToTaskModelStatus(source.Status),
                Term = source.Term,
                Topic = source.Topic,
            };
        }
    }
}