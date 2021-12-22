using System;
using System.Collections.Generic;
using Application.Entities;

namespace Application.ApiInterface
{
    public interface IBoardApi
    {
        public void CreateBoard(BoardRecord board, string email);
        public void DeleteBoard(Guid boardId);
        public void AddTaskToBoard(Guid boardId, TaskRecord task, string email);
        public IEnumerable<TaskRecord> GetBoardTasks(Guid boardId);
        public string GetBoardName(Guid boardId);
        public bool GetBoardPrivacy(Guid boardId);
        public BoardRecord GetBoard(Guid boardId);
        public void AddNewUserToBoard(string email, Guid boardId);
        public void UpdateTaskOnBoard(Guid boardId, TaskRecord task, string email);
        public void DeleteTaskOnBoard(Guid boardId, Guid idTask);
    }
}