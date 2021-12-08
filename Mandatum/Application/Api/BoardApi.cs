using System;
using System.Collections.Generic;
using Application.ApiInterface;
using Domain;

namespace Application
{
    public class BoardApi: IBoardApi
    {
        private readonly BoardRepo boardRepo;
        private readonly UserApi userApi;
        private readonly TaskApi taskApi;

        public BoardApi(BoardRepo boardRepo, UserApi userApi, TaskApi taskApi)
        {
            this.boardRepo = boardRepo;
            this.userApi = userApi;
            this.taskApi = taskApi;
        }

        public void CreateBoard(BoardRecord board, string email)
        {
            boardRepo.SaveBoard(board);
            userApi.AddBoard(board, email);
        }

        public void DeleteBoard(Guid boardId)
        {
            
        }

        public string GetBoardName(Guid boardId)
        {
            var board = boardRepo.GetBoard(boardId);
            return board.Name;
        }   
        
        public IEnumerable<TaskRecord> GetTasks(Guid boardId)
        {
            var board = boardRepo.GetBoard(boardId);
            return board.TaskIds;
        }
        
        public void AddTask(Guid boardId, TaskRecord task)
        {
            taskApi.SaveTask(task);
            var board = boardRepo.GetBoard(boardId);
            board.TaskIds.Add(task);
            boardRepo.UpdateBoard(board);
        }
    }
}