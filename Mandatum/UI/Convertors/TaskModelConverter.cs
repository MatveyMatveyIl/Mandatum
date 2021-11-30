using System.Collections.Generic;
using Application;
using Mandatum.Models;
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

        private TaskStatusRecord ConvertToTaskRecordStatus(TaskStatus statusRecord)
        {
            return statusRecord switch
            {
                TaskStatus.Done => TaskStatusRecord.Done,
                TaskStatus.InProgress => TaskStatusRecord.InProgress,
                TaskStatus.InWait => TaskStatusRecord.InWait
            };
        }
        
        private TaskStatus ConvertToTaskModelStatus(TaskStatusRecord statusRecord)
        {
            return statusRecord switch
            {
                TaskStatusRecord.Done => TaskStatus.Done,
                TaskStatusRecord.InProgress => TaskStatus.InProgress,
                TaskStatusRecord.InWait => TaskStatus.InWait
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

        public IEnumerable<TaskModel> Convert(IEnumerable<TaskRecord> records)
        {
            foreach (var record in records)
            {
                yield return Convert(record);
            }
        }
    }
}