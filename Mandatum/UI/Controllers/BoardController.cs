using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mandatum.Controllers
{
    public class BoardController : Controller
    {
        public IActionResult NewBoard()
        {
            return View();
        }
    }
}