using System;
using System.Collections.Generic;

namespace Application.ApiInterface
{
    public interface IBoardApi
    {
        public void CreateBoard(BoardRecord board, string email);
        public void DeleteBoard(Guid boardId);
        public void AddTask(Guid boardId, TaskRecord task);
        public IEnumerable<TaskRecord> GetTasks(Guid boardId);
        public string GetBoardName(Guid boardId);
    }
}