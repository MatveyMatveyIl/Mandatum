using System;
using System.Collections.Generic;
using Application.ApiInterface;
using Mandatum.Convertors;
using Mandatum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mandatum.Controllers
{
    public class TaskController : Controller
    {
        private ITaskApi _taskApi;
        private IBoardApi _boardApi;
        private TaskModelConverter _taskConverter;
        private BoardModelConverter _boardConverter;

        public TaskController(ITaskApi taskApi, IBoardApi boardApi, TaskModelConverter taskConverter, BoardModelConverter boardConverter)
        {
            _taskApi = taskApi;
            _taskConverter = taskConverter;
            _boardApi = boardApi;
            _boardConverter = boardConverter;
        }
        
         public IActionResult CreateTask(Guid boardId, TaskStatus taskStatus)
        {
            var taskView = new TaskViewModel(boardId, new TaskModel() {Status = taskStatus}, nameof(CreateTask));
            return View("EditTask", taskView);
        }

        public IActionResult EditTask(Guid taskId, Guid boardId)
        {
            var taskView = new TaskViewModel(boardId,_taskConverter.Convert(_taskApi.GetTask(taskId)), nameof(EditTask));
            return View("EditTask", taskView);
        }

        public IActionResult SaveTask(TaskModel taskModel, Guid boardId)
        {
            var taskView = new TaskViewModel(boardId, new TaskModel(), nameof(CreateTask));
            if (ModelState.IsValid)
            {
                _boardApi.AddTaskToBoard(boardId, _taskConverter.Convert(taskModel));
                var boardView = new BoardViewModel(_boardConverter.Convert(_boardApi.GetBoard(boardId)),
                    GetTasks(boardId));
                return View("BoardView", boardView);
            }

            return View("EditTask", taskView);
        }
        
        public IActionResult UpdateTask(TaskModel taskModel, Guid boardId)
        {
            _boardApi.UpdateTaskOnBoard(boardId, _taskConverter.Convert(taskModel));
            
            var boardView = new BoardViewModel(_boardConverter.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            
            return View("BoardView", boardView);
        }

        public IActionResult CancelTask(Guid boardId)
        {
            var boardView = new BoardViewModel(_boardConverter.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            return View("BoardView", boardView);
        }

        
        public IActionResult ShareBoard(String userEmail, Guid boardId)
        {
            var boardView = new BoardViewModel(_boardConverter.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            return View("BoardView", boardView);
        }
        
        private IEnumerable<TaskModel> GetTasks(Guid boardId)
        {
            return _taskConverter.Convert(_boardApi.GetBoardTasks(boardId));
        }
        
        public IActionResult DeleteTask(Guid taskId, Guid boardId)
        {
            _boardApi.DeleteTaskOnBoard(boardId, taskId);
            
            var boardView = new BoardViewModel(_boardConverter.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            
            return View("BoardView", boardView);
        }
    }
}