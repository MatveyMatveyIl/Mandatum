using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Application.ApiInterface;
using Application.Entities;
using AspNet.Security.OAuth.GitHub;
using Mandatum.Convertors;
using Mandatum.infra;
using Mandatum.Models;
using Mandatum.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoogleHandler = Mandatum.infra.GoogleHandler;
using Task = System.Threading.Tasks.Task;

namespace Mandatum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApi _userApi;
        private readonly UserManager<UserRecord> _userManager;
        private readonly SignInManager<UserRecord> _signInManager;
        private readonly ResponseHandler _handler;
        
        

        public AccountController(UserManager<UserRecord> userManager, SignInManager<UserRecord> signInManager,
            IUserApi userApi)
        {
            _userApi = userApi;
            _userManager = userManager;
            _signInManager = signInManager;
            _handler = new ResponseHandler();
        }
        
        public async Task<IActionResult> Response(AuthType auth)
        {
            var response = await HttpContext.AuthenticateAsync(LoginParams.Schemes[auth]);
            await _handler.Auth(_userManager, _signInManager, response, auth);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null, AuthType authType=AuthType.Mandatum)
        {
            if (authType==AuthType.Mandatum)
                return View(new LoginModel {AuthType = authType, ReturnUrl = returnUrl});
            var properties = new AuthenticationProperties {RedirectUri = Url.Action("Response",new {auth=authType} )};
            var challenge =  Challenge(properties, LoginParams.Schemes[authType]);
            return challenge;
            
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel model)
        {
      
                if (!ModelState.IsValid) return View(model);
                var result = 
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                return View(model);
        }
 
        
        public async Task<IActionResult> Logout()
        {
            
            await _signInManager.SignOutAsync();
            return Redirect("~/Home/Index");
        }

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

    }
}