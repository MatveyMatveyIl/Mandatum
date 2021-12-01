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
        private TaskModelConverter _taskConverter;

        public BoardController(TaskApi taskApi, TaskModelConverter taskConverter)
        {
            _taskApi = taskApi;
            _taskConverter = taskConverter;
        }
        
        public IActionResult KanbanBoard(Guid id = default)
        {
            ViewBag.current_task_id = id;
            return View(_taskConverter.Convert(_taskApi.GetTasks()));
        }

        public IActionResult CreateTask()
        {
            ViewBag.Method = nameof(CreateTask);
            return View("CreateTask", new TaskModel());
        }

        public IActionResult EditTask(TaskModel task)
        {
            ViewBag.Method = nameof(EditTask);
            return View("EditTask", task);
            // return View("KanbanBoard", _taskConverter.Convert(_taskApi.GetTasks()));
            // return View("CreateTask", _taskConverter.Convert(_taskApi.GetTask(_taskConverter.Convert(task))));
        }

        public IActionResult SaveTask(TaskModel task)
        {
            _taskApi.AddTask(_taskConverter.Convert(task));
            return View("KanbanBoard", _taskConverter.Convert(_taskApi.GetTasks()));
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