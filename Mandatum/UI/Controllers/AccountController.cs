
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.ApiInterface;
using Application.Entities;
using Mandatum.infra;

using Mandatum.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Mandatum.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApi _userApi;
        private readonly UserManager<UserRecord> _userManager;
        private readonly SignInManager<UserRecord> _signInManager;
        private readonly IEnumerable<IOAuthType> _authTypes;
        private readonly Dictionary<string, string> _registrationErrors;

        public AccountController(UserManager<UserRecord> userManager, SignInManager<UserRecord> signInManager,
            IUserApi userApi, IEnumerable<IOAuthType> authTypes)
        {
            _userApi = userApi;
            _userManager = userManager;
            _signInManager = signInManager;
            _authTypes = authTypes;
            _registrationErrors = new Dictionary<string, string>
            {
                ["PasswordTooShort"] = "Пароль должен состоять из 6 или более символов",
                ["PasswordRequiresNonAlphanumeric"] = "Пароль должен содержать как минимум одну цифру",
                ["PasswordRequiresLower"] = "Пароль должен содержать хотя бы одну маленькую букву из английского алфавита ('a'-'z')",
                ["PasswordRequiresUpper"] = "Пароль должен содержать хотя бы одну заглавную букву из английского алфавита ('A'-'Z')"
            };
        }
        

        [HttpGet]
        public IActionResult Login(string returnUrl = null, AuthType authType=AuthType.Mandatum)
        {
            return View(new LoginModel { ReturnUrl = returnUrl});
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
                        ModelState.AddModelError(string.Empty, _registrationErrors[error.Code]);
                    }
                }
            }

            return View(model);
        }

    }
}