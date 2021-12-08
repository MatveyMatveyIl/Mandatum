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
        private readonly BoardApi _boardApi;

        public HomeController(BoardApi boardApi)
        {
            _boardApi = boardApi;
        }
    

        public IActionResult Index()
        {
            //_boardApi.Fuck();
            return View();
        }
    }
}