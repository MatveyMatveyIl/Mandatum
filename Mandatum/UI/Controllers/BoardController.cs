using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Application.ApiInterface;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BoardFormat = Mandatum.Models.BoardFormat;

namespace Mandatum.Controllers
{
    public class BoardController : Controller
    {
        private ITaskApi _taskApi;
        private IBoardApi _boardApi;
        private TaskModelConverter _taskConverter;
        private BoardModelConvertor _boardModelConvertor;
        private IUserApi _userApi;

        public BoardController(ITaskApi taskApi, IBoardApi boardApi, IUserApi userApi, TaskModelConverter taskConverter, 
            BoardModelConvertor boardModelConvertor)
        {
            _taskApi = taskApi;
            _taskConverter = taskConverter;
            _boardApi = boardApi;
            _boardModelConvertor = boardModelConvertor;
            _userApi = userApi;
        }

        #region Boards
        
        public IActionResult AllBoards()
        {
            //Console.WriteLine(User.Identity.Name);
            return View(_boardModelConvertor.Convert(_userApi.GetBoards(User.Identity.Name)));
        }

        public IActionResult OpenBoard(Guid boardId, BoardFormat boardFormat)
        {
            ViewBag.boardId = boardId;
            ViewBag.boardName = _boardApi.GetBoardName(boardId);
            return View(boardFormat.ToString(), GetTasks(boardId));
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
            ViewBag.boardName = _boardApi.GetBoardName(board.Id);
            return View("KanbanBoard", GetTasks(board.Id));
        } 

        #endregion

        #region Tasks

        public IActionResult CreateTask(Guid boardId, TaskStatus taskStatus)
        {
            ViewBag.Method = nameof(CreateTask);
            ViewBag.boardId = boardId;
            var taskModel = new TaskModel {Status = taskStatus};
            return View("EditTask", taskModel);
        }

        public IActionResult EditTask(Guid taskId, Guid boardId)
        {
            ViewBag.Method = nameof(EditTask);
            ViewBag.boardId = boardId;
            var task = _taskApi.GetTask(taskId);
            return View(_taskConverter.Convert(_taskApi.GetTask(taskId)));
        }

        public IActionResult SaveTask(TaskModel taskModel, Guid boardId)
        {
            _boardApi.AddTaskToBoard(boardId, _taskConverter.Convert(taskModel));
            ViewBag.boardId = boardId;
            ViewBag.boardName = _boardApi.GetBoardName(boardId);
            return View("KanbanBoard", GetTasks(boardId));
        }
        
        public IActionResult UpdateTask(TaskModel taskModel, Guid boardId)
        {
            _boardApi.UpdateTaskOnBoard(boardId, _taskConverter.Convert(taskModel));
            ViewBag.boardId = boardId;
            ViewBag.boardName = _boardApi.GetBoardName(boardId);
            return View("KanbanBoard", GetTasks(boardId));
        }

        public IActionResult CancelTask(Guid boardId)
        {
            ViewBag.boardId = boardId;
            ViewBag.boardName = _boardApi.GetBoardName(boardId);
            return View("KanbanBoard", GetTasks(boardId));
        }

        private IEnumerable<TaskModel> GetTasks(Guid boardId)
        {
            return _taskConverter.Convert(_boardApi.GetBoardTasks(boardId));
        }

        #endregion
    }
}