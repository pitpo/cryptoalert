using Microsoft.AspNetCore.Mvc;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Authentication;
using Newtonsoft.Json;
using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using CryptoAlertCore.Models;

namespace CryptoAlert.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginViewModel _loginViewModel = new LoginViewModel();

        public IActionResult Index()
        {
            return View(_loginViewModel);
        }

        [HttpPost]
        public IActionResult Index(string email, string pass)
        {
            IUserAuthenticationService userAuthenticationService = new UserAuthenticationServiceFactory().Create();
            var userLogin = new UserLogin
            {
                Email = email,
                Password = pass
            };

            var token = AuthenticateUser(userLogin, userAuthenticationService);
            if (token == null)
            {
                _loginViewModel.IncorrectPassword = true;
                return View(_loginViewModel);
            }

            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24)
            };
            Response.Cookies.Append("jwt", token.Content, cookieOptions);

            return RedirectToAction("Index", "Coins");
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Index", "Coins");
        }

        private Token AuthenticateUser(UserLogin userLogin, IUserAuthenticationService userAuthenticationService)
        {
            return userAuthenticationService.AuthenticateUserFromJson(JsonConvert.SerializeObject(userLogin));
        }
    }
}
