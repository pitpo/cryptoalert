using CryptoAlert.WebApp.Models;
using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlert.WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly RegisterViewModel _registerViewModel = new RegisterViewModel();

        public IActionResult Index()
        {
            return View(_registerViewModel);
        }

        [HttpPost]
        public IActionResult Index(string name, string email, string pass)
        {
            IUserAuthenticationService userAuthenticationService = new UserAuthenticationServiceFactory().Create();
            var user = new UserRegister
            {
                Name = name,
                Email = email,
                Password = pass
            };
            bool status = userAuthenticationService.InsertUserFromJsonToDb(JsonConvert.SerializeObject(user));
            if (!status)
            {
                _registerViewModel.EmailExists = true;
                return View(_registerViewModel);
            }
            var userLogin = new UserLogin
            {
                Email = email,
                Password = pass
            };
            var token = userAuthenticationService.AuthenticateUserFromJson(JsonConvert.SerializeObject(userLogin));
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24)
            };
            Response.Cookies.Append("jwt", token.Content, cookieOptions);
            return RedirectToAction("Index", "Coins");
        }
    }
}
