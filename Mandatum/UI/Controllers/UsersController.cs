using System.Collections.Generic;
using Application;
using Microsoft.AspNetCore.Mvc;

namespace AuthUsers.Controllers
{
    public class UserController : Controller
    {
        public ActionResult UsersList()
        {
            Dictionary<string, object> data
                = new Dictionary<string, object>();
            data.Add("Ключ", "Значение");

            return View(data);
        }
    }
}