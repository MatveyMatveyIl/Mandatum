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
        private TaskConverterUILayer _taskConverterUiLayer;
        private BoardConverterUILayer _boardConverterUiLayer;

        public TaskController(ITaskApi taskApi, IBoardApi boardApi, TaskConverterUILayer taskConverterUiLayer, BoardConverterUILayer boardConverterUiLayer)
        {
            _taskApi = taskApi;
            _taskConverterUiLayer = taskConverterUiLayer;
            _boardApi = boardApi;
            _boardConverterUiLayer = boardConverterUiLayer;
        }
        
         public IActionResult CreateTask(Guid boardId, TaskStatus taskStatus)
        {
            var taskView = new TaskViewModel(boardId, new TaskModel() {Status = taskStatus}, nameof(CreateTask));
            return View("EditTask", taskView);
        }

        public IActionResult EditTask(Guid taskId, Guid boardId)
        {
            var taskView = new TaskViewModel(boardId,_taskConverterUiLayer.Convert(_taskApi.GetTask(taskId)), nameof(EditTask));
            return View("EditTask", taskView);
        }

        public IActionResult SaveTask(TaskModel taskModel, Guid boardId)
        {
            var taskView = new TaskViewModel(boardId, new TaskModel(), nameof(CreateTask));
            if (!ModelState.IsValid) return View("EditTask", taskView);
            _boardApi.AddTaskToBoard(boardId, _taskConverterUiLayer.Convert(taskModel));
            var boardView = new BoardViewModel(_boardConverterUiLayer.Convert(_boardApi.GetBoard(boardId)),
                GetTasks(boardId));
            return View("BoardView", boardView);

        }
        
        public IActionResult UpdateTask(TaskModel taskModel, Guid boardId)
        {
            var taskView = new TaskViewModel(boardId, taskModel, nameof(EditTask));
            if (!ModelState.IsValid) return View("EditTask", taskView);
            _boardApi.UpdateTaskOnBoard(boardId, _taskConverterUiLayer.Convert(taskModel));
            var boardView = new BoardViewModel(_boardConverterUiLayer.Convert(_boardApi.GetBoard(boardId)),
                GetTasks(boardId));
            return View("BoardView", boardView);
        }

        public IActionResult CancelTask(Guid boardId)
        {
            var boardView = new BoardViewModel(_boardConverterUiLayer.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            return View("BoardView", boardView);
        }

        private IEnumerable<TaskModel> GetTasks(Guid boardId)
        {
            return _taskConverterUiLayer.Convert(_boardApi.GetBoardTasks(boardId));
        }
        
        public IActionResult DeleteTask(Guid taskId, Guid boardId)
        {
            _boardApi.DeleteTaskOnBoard(boardId, taskId);
            var boardView = new BoardViewModel(_boardConverterUiLayer.Convert(_boardApi.GetBoard(boardId)), GetTasks(boardId));
            return View("BoardView", boardView);
        }
    }
}