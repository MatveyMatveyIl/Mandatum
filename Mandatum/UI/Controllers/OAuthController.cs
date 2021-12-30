using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.ApiInterface;
using Application.Entities;
using Mandatum.infra;
using Mandatum.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mandatum.Controllers
{
    public class OAuthController: Controller
    {
        private readonly IUserApi _userApi;
        private readonly UserManager<UserRecord> _userManager;
        private readonly SignInManager<UserRecord> _signInManager;
        private readonly ResponseHandler _handler;
        private readonly IEnumerable<IOAuthType> _authTypes;

        public OAuthController(UserManager<UserRecord> userManager, SignInManager<UserRecord> signInManager, ResponseHandler handler,
            IUserApi userApi, IEnumerable<IOAuthType> authTypes)
        {
            _userApi = userApi;
            _userManager = userManager;
            _signInManager = signInManager;
            _handler = handler;
            _authTypes = authTypes;
        }

        public async Task<IActionResult> Response(string authScheme, string emailKey)
        {
            var response = await HttpContext.AuthenticateAsync(authScheme);
            await _handler.Auth(_userManager, _signInManager, response, emailKey);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login(string scheme, string key)
        {
            var properties = new AuthenticationProperties {RedirectUri = Url.Action("Response",new {authScheme=scheme, emailKey=key} )};
            var challenge =  Challenge(properties ,scheme);
            return challenge;   
            
        }
    }
}