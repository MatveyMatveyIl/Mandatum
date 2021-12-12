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
        public void DeleteTaskOnBoard(Guid boardId, Guid idTask)
        {
            var task = _taskApi.GetTask(idTask);
            _taskApi.DeleteTask(idTask);
            var board = _boardRepo.GetBoard(boardId);
            board.TaskIds.Remove(task);
            _boardRepo.UpdateBoard(board);
        }

        public string GetBoardName(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            return board.Name;
        }

        public bool GetBoardPrivacy(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            return board.Privacy;
        }

        public BoardRecord GetBoard(Guid boardId)
        {
            return _boardRepo.GetBoard(boardId);
        }

        public void AddNewUserToBoard(string email, Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            _userApi.AddBoard(board, email);
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
            board.TaskIds.Add(task);
            _boardRepo.UpdateBoard(board);
        }
    }
}