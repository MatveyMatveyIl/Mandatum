using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mandatum.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private TaskApi _taskApi;
        private BoardApi _boardApi;
        private TaskModelConverter _taskConverter;
        private BoardModelConvertor _boardModelConvertor;
        private UserApi _userApi;

        public BoardController(TaskApi taskApi, BoardApi boardApi, UserApi userApi, TaskModelConverter taskConverter, 
            BoardModelConvertor boardModelConvertor)
        {
            _taskApi = taskApi;
            _taskConverter = taskConverter;
            _boardApi = boardApi;
            _boardModelConvertor = boardModelConvertor;
            _userApi = userApi;
        }

        #region Boards

        public IActionResult KanbanBoard(BoardModel board)
        {
            ViewBag.boardId = board.Id;
            return View(GetTasks(board.Id));
        }

        public IActionResult AllBoards()
        {
            // var boards = _boardModelConvertor.Convert(_userApi.GetBoards(User.Identity.Name));
            return View();
        }

        public IActionResult CreateBoard()
        {
            return View("CreateBoard", new BoardModel());
        }
        
        public IActionResult SaveBoard(BoardModel board)
        {
            board.Id = Guid.NewGuid();
            var boardRecord = _boardModelConvertor.Convert(board);
            _boardApi.CreateBoard(boardRecord, User.Identity.Name);
            ViewBag.boardId = board.Id;
            return View("KanbanBoard", GetTasks(board.Id));
        } 

        #endregion

        #region Tasks

        public IActionResult CreateTask(Guid boardId, TaskStatus taskStatus)
        {
            Console.WriteLine(boardId.ToString());
            ViewBag.Method = nameof(CreateTask);
            ViewBag.boardId = boardId;
            var task = new TaskModel {Status = taskStatus};
            return View("EditTask", task);
        }

        public IActionResult EditTask(TaskModel task, Guid boardId)
        {
            ViewBag.Method = nameof(EditTask);
            ViewBag.boardId = boardId;
            return View("EditTask", task);
        }

        public IActionResult SaveTask(TaskModel task, Guid boardId)
        {
            _boardApi.AddTask(boardId, _taskConverter.Convert(task));
            ViewBag.boardId = boardId;
            return View("KanbanBoard", GetTasks(boardId));
        }

        public IActionResult CancelTask(Guid boardId)
        {
            var board = _boardModelConvertor.Convert(_boardApi.GetBoard(boardId));
            ViewBag.boardId = board.Id;
            
            return View("KanbanBoard", GetTasks(boardId));
        }

        private IEnumerable<TaskModel> GetTasks(Guid boardId)
        {
            return _taskConverter.Convert(_taskApi.GetBoardTasks(boardId));
        }

        #endregion
    }
}