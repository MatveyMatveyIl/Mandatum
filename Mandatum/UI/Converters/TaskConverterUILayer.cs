using System.Collections.Generic;
using Application;
using Application.Entities;
using Mandatum.Models;
using Mandatum.ViewModels;

namespace Mandatum.Convertors
{
    public class TaskConverterUILayer: IConverter<TaskRecord, TaskModel>
    {
        public TaskRecord Convert(TaskModel source)
        {
            return new TaskRecord()
            {
                Id = source.Id,
                Description = source.Description,
                Status = ConvertToTaskRecordStatus(source.Status),
                Deadline = source.Deadline,
                Executors = source.Executors,
                Name = source.Topic,
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
                Id = source.Id,
                Description = source.Description,
                Status = ConvertToTaskModelStatus(source.Status),
                Deadline = source.Deadline,
                Executors = source.Executors,
                Topic = source.Name,
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