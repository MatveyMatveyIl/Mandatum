using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using Application;
using Application.ApiInterface;
using Mandatum.Convertors;
using Mandatum.Models;
using Mandatum.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Mandatum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApi _userApi;
        private readonly UserConverterModel _converterModel;
        private readonly UserConverterRegister _converterRegister;
        private readonly UserManager<UserRecord> _userManager;
        private readonly SignInManager<UserRecord> _signInManager;

        public AccountController(UserManager<UserRecord> userManager, SignInManager<UserRecord> signInManager,
            IUserApi userApi, UserConverterModel converterModel, UserConverterRegister converterRegister)
        {
            _userApi = userApi;
            _converterModel = converterModel;
            _converterRegister = converterRegister;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };

            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }
        
        public async Task<IActionResult> GoogleResponse()
        {
            
            var response = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var email = response.Principal?.Identities.FirstOrDefault()
                .Claims
                .Where(claim => (claim.Type.Split("/").Last() =="emailaddress" ))
                .Select(claim => claim.Value.Split("/").Last())
                .FirstOrDefault();
          
            
            var user = new UserRecord() {Email = email, UserName = email};
            if (await _userManager.GetUserAsync(response.Principal) is null)
            {
                var result = await _userManager.CreateAsync(user, "Qwer1%");

            }

            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
            
        }
     
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            
            return View(new LoginModel { ReturnUrl = returnUrl });
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
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            }
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