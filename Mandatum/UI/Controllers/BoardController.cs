using System.Collections.Generic;
using Mandatum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mandatum.Controllers
{
    public class BoardController : Controller
    {
    
        public IActionResult KanbanBoard()
        {
            return View();
        }
        
        public IActionResult CreateTask()
        {
            return View("CreateTask", new Task());
        }

        public IActionResult CreateBoard()
        {
            return View();
        }

        public IActionResult AllBoards()
        {
            return View();
        }
    }
}