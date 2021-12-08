using System;
using System.Collections.Generic;
using Application.ApiInterface;

namespace Application
{
    public class BoardApi : IBoardApi
    {
        private readonly IBoardRepo _boardRepo;
        private readonly IUserApi _userApi;
        private readonly ITaskApi _taskApi;

        public BoardApi(IBoardRepo boardRepo, IUserApi userApi, ITaskApi taskApi)
        {
            _boardRepo = boardRepo;
            _userApi = userApi;
            _taskApi = taskApi;
        }

        public void CreateBoard(BoardRecord board, string email)
        {
            _boardRepo.SaveBoard(board);
            _userApi.AddBoard(board, email);
        }

        public void DeleteBoard(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            _boardRepo.DeleteBoard(board);
        }

        public string GetBoardName(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            return board.Name;
        }

        public void AddNewUserToBoard(string email, Guid boardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRecord> GetBoardTasks(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            return board.TaskIds;
        }

        public void AddTaskToBoard(Guid boardId, TaskRecord task)
        {
            _taskApi.SaveTask(task);
            var board = _boardRepo.GetBoard(boardId);
            board.TaskIds.Add(task);
            _boardRepo.UpdateBoard(board);
        }
        public void UpdateTaskOnBoard(Guid boardId, TaskRecord task)
        {
            _taskApi.UpdateTask(task);
            var board = _boardRepo.GetBoard(boardId);
            _boardRepo.UpdateBoard(board);
        }
    }
}