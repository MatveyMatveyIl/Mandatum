using System.Collections.Generic;
using Application;
using Mandatum.Models;

namespace Mandatum.Convertors
{
    public class TaskConverter
    {
        public TaskModel ConvertToTaskModel(TaskRecord taskRecord)
        {
            return new TaskModel()
            {
                Name = taskRecord.Name, Status = ConvertToTaskStatus(taskRecord.Status),
                Id = taskRecord.Id, Deadline = taskRecord.Deadline, Executors = taskRecord.Executors, 
                Priority = taskRecord.Priority, Description = taskRecord.Description
            };
        }
        
        public TaskStatus ConvertToTaskStatus(TaskStatusRecord statusRecord)
        {
            return statusRecord switch
            {
                TaskStatusRecord.Done => TaskStatus.Done,
                TaskStatusRecord.InProgress => TaskStatus.InProgress,
                TaskStatusRecord.InWait => TaskStatus.InWait
            };
        }

        public IEnumerable<TaskModel> ConvertToTaskModels(IEnumerable<TaskRecord> taskRecords)
        {
            foreach (var taskRecord in taskRecords)
            {
                yield return ConvertToTaskModel(taskRecord);
            }
        }
    }
}