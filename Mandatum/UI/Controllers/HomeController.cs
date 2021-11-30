using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mandatum.Models;
using Microsoft.AspNetCore.Authorization;

namespace Mandatum.Controllers
{
    public class HomeController : Controller
    {
        // private readonly ILogger<HomeController> _logger;
        //
        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }
        private readonly BoardApi _boardApi;

        public HomeController(BoardApi boardApi)
        {
            _boardApi = boardApi;
        }

        public IActionResult Index()
        {
            _boardApi.Fuck();
            return View();
        }
        
        public IActionResult CreateBoard()
        {
            return View();
        }

        public IActionResult AllBoards()
        {
            return View();
        }
        
        
        // public IActionResult Privacy()
        // {
        //     return View();
        // }
        //
        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        // }
    }
}