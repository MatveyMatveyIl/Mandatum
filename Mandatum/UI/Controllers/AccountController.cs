using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Mandatum.Convertors;
using Mandatum.Models;
using Mandatum.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Mandatum.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserApi _userApi;
        private readonly UserConvertorModel _convertorModel;
        private readonly UserConvertorRegister _convertorRegister;
        private readonly UserManager<UserRecord> _userManager;
        private readonly SignInManager<UserRecord> _signInManager;

        public AccountController(UserManager<UserRecord> userManager, SignInManager<UserRecord> signInManager, UserApi userApi, UserConvertorModel convertorModel, UserConvertorRegister convertorRegister)
        {
            _userApi = userApi;
            _convertorModel = convertorModel;
            _convertorRegister = convertorRegister;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // public async Task<IActionResult> Login(LoginModel model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var user = _userApi.CheckUser(_convertorModel.Convert(model));
        //         if (user != null)
        //         {
        //             await Authenticate(user.Id); // аутентификация
        //             Console.WriteLine(user.Id);
        //             return RedirectToAction("Index", "Home");
        //         }
        //
        //         ModelState.AddModelError("", "Некорректные логин и(или) пароль");
        //     }
        //
        //     return View(model);
        // }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserRecord() {Email = model.Email, UserName = model.Email};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        // private async Task Authenticate(Guid userName)
        // {
        //     // создаем один claim
        //     var claims = new List<Claim>
        //     {
        //         new Claim(ClaimsIdentity.DefaultNameClaimType, userName.ToString())
        //     };
        //     // создаем объект ClaimsIdentity
        //     ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
        //         ClaimsIdentity.DefaultRoleClaimType);
        //     // установка аутентификационных куки
        //     await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        //     //Console.WriteLine(id);
        //     Console.WriteLine(userName);
        // }
        
    }
}