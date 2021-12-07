using System;
using System.Collections.Generic;
using System.Linq;
using Application;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mandatum.Controllers
{
    public class BoardController : Controller
    {
        private TaskApi _taskApi;
        private BoardApi _boardApi;
        private TaskModelConverter _taskConverter;
        private BoardModelConvertor _boardModelConvertor;

        public BoardController(TaskApi taskApi, BoardApi boardApi, TaskModelConverter taskConverter, 
            BoardModelConvertor boardModelConvertor)
        {
            _taskApi = taskApi;
            _taskConverter = taskConverter;
            _boardApi = boardApi;
            _boardModelConvertor = boardModelConvertor;
        }

        #region Boards

        public IActionResult KanbanBoard(Guid id = default)
        {
            ViewBag.current_task_id = id;
            return View(_taskConverter.Convert(_taskApi.GetTasks()));
        }

        public IActionResult AllBoards()
        {
            return View();
        }

        public IActionResult CreateBoard()
        {
            return View("CreateBoard", new BoardModel());
        }
        
        public IActionResult SaveBoard(BoardModel board)
        {
            board.Id = new Guid();
            _boardApi.CreateBoard(_boardModelConvertor.Convert(board), User.Identity.Name);
            return View("KanbanBoard", _taskConverter.Convert(_taskApi.GetTasks()));
        } 

        #endregion

        #region Tasks

        public IActionResult CreateTask()
        {
            ViewBag.Method = nameof(CreateTask);
            return View("EditTask", new TaskModel());
        }

        public IActionResult EditTask(TaskModel task)
        {
            ViewBag.Method = nameof(EditTask);
            return View("EditTask", task);
        }

        public IActionResult SaveTask(TaskModel task)
        {
            _taskApi.SaveTask(_taskConverter.Convert(task));
            
            return View("KanbanBoard", _taskConverter.Convert(_taskApi.GetTasks()));
        }

        #endregion
    }
}