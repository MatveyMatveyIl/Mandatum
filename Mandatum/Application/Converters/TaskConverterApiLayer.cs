using System.Collections.Generic;
using Domain;
using Mandatum.Convertors;

namespace Application.Converters
{
    public class TaskConverterAppLayer: IConverter<TaskRecord, Task>
    {
        public TaskRecord Convert(Task source)
        {
            return new TaskRecord()
            {
                Id = source.Id,
                Description = source.Description,
                Status = ConvertToTaskRecordStatus(source.Status),
                Deadline = source.Deadline,
                Executors = source.Executors,
                Name = source.Name,
            };
        }

        public Task Convert(TaskRecord source)
        {
            return new Task()
            {
                Id = source.Id,
                Description = source.Description,
                Status = ConvertToTaskDomainStatus(source.Status),
                Deadline = source.Deadline,
                Executors = source.Executors,
                Name = source.Name,
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
        
        private TaskStatus ConvertToTaskDomainStatus(TaskStatusRecord statusRecord)
        {
            return statusRecord switch
            {
                TaskStatusRecord.Done => TaskStatus.Done,
                TaskStatusRecord.InProgress => TaskStatus.InProgress,
                TaskStatusRecord.InWait => TaskStatus.InWait
            };
        }

        public IEnumerable<TaskRecord> Converts(IEnumerable<Task> tasks)
        {
            foreach (var task in tasks)
            {
                yield return Convert(task);
            }
        }
        
        public IEnumerable<Task> Converts(IEnumerable<TaskRecord> tasks)
        {
            foreach (var task in tasks)
            {
                yield return Convert(task);
            }
        }
    }
}