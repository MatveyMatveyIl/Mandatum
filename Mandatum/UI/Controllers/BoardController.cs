using System;
using System.Collections.Generic;
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
        private TaskConverter _taskConverter;

        public BoardController(TaskApi taskApi, TaskConverter taskConverter)
        {
            _taskApi = taskApi;
            _taskConverter = taskConverter;
        }
        
        public IActionResult KanbanBoard(Guid id = default)
        {
            ViewBag.current_task_id = id;
            return View(_taskConverter.ConvertToTaskModels(_taskApi.GetTasks()));
        }

        public IActionResult CreateTask(Guid? id)
        {
            ViewBag.id = id;
            ViewBag.Method = nameof(CreateTask);
            return View("CreateTask", new TaskModel());
        }

        public IActionResult EditTask(Guid id)
        {
            ViewBag.Method = nameof(EditTask);
            return View("CreateTask", _taskConverter.ConvertToTaskModel(_taskApi.GetTask(id)));
        }

        public IActionResult AllBoards()
        {
            return View();
        }

        public IActionResult CreateBoard()
        {
            return View();
        }
    }
}