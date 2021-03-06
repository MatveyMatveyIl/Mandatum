using System;
using System.Collections.Generic;
using System.Linq;
using Application.ApiInterface;
using Application.Converters;
using Application.DbContext;
using Application.Entities;
using Application.RepositoryInterface;

namespace Application.Api
{
    public class BoardApi : IBoardApi
    {
        private readonly IBoardRepo _boardRepo;
        private readonly IUserApi _userApi;
        private readonly ITaskApi _taskApi;
        private readonly BoardConverterApiLayer _boardConverter;
        private readonly TaskConverterAppLayer _taskConverter;
        private readonly AppDbContext _dbContext;

        public BoardApi(IBoardRepo boardRepo, IUserApi userApi, ITaskApi taskApi, BoardConverterApiLayer boardConverter,
            TaskConverterAppLayer taskConverter, AppDbContext dbContext)
        {
            _boardRepo = boardRepo;
            _userApi = userApi;
            _taskApi = taskApi;
            _boardConverter = boardConverter;
            _taskConverter = taskConverter;
            _dbContext = dbContext;
        }

        public void CreateBoard(BoardRecord board, string email)
        {
            var boards = _userApi.GetBoards(email);
            if (boards.FirstOrDefault(b => b.Name == board.Name) is not null) return;
            _boardRepo.SaveBoard(board);
            _userApi.AddBoard(board, email);
        }

        public void DeleteBoard(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            if(board is null) return;
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
            if(_userApi.GetUser(email) is null) return;
            _userApi.AddBoard(board, email);
        }

        public IEnumerable<TaskRecord> GetBoardTasks(Guid boardId)
        {
            var board = _boardRepo.GetBoard(boardId);
            return board.TaskIds;
        }

        public void AddTaskToBoard(Guid boardId, TaskRecord task, string email)
        {
            task.Id = Guid.NewGuid();
            _taskApi.SaveTask(task);
            UpdateBoard(boardId, task, email, out var _);
        }

        public void UpdateTaskOnBoard(Guid boardId, TaskRecord task, string email)
        {
            UpdateBoard(boardId, task, email, out var edit);
            if(edit) _taskApi.UpdateTask(task); 
        }
        
        private void UpdateBoard(Guid boardId, TaskRecord task, string email, out bool correctEdit)
        {
            var board = _boardRepo.GetBoard(boardId);
            var boardDomain = _boardConverter.Convert(board);
            var taskDomain = _taskConverter.Convert(task);
            correctEdit = boardDomain.AddTask(taskDomain, email);
            if (correctEdit)
            {
                board = _boardConverter.Convert(boardDomain);
                _boardRepo.UpdateBoard(board);
            }
        }
    }
}