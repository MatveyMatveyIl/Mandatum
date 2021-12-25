using System.Collections.Generic;
using System.Linq;
using Application.DbContext;
using Application.Entities;
using Domain;
using Mandatum.Convertors;

namespace Application.Converters
{
    public class TaskConverterAppLayer: IConverter<TaskRecord, Task>
    {
        private readonly AppDbContext _dbContext;

        public TaskConverterAppLayer(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TaskRecord Convert(Task source)
        {
            var taskRecord = _dbContext.Tasks.FirstOrDefault(t => t.Id == source.Id);
            taskRecord.Name = source.Name;
            taskRecord.Status = ConvertToTaskRecordStatus(source.Status);
            taskRecord.Deadline = source.Deadline;
            taskRecord.Executors = source.Executors;
            taskRecord.Description = source.Description;
            return taskRecord;
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