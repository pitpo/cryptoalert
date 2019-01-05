using CryptoAlert.WebApp.Models;
using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

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
            var (userRegister, userLogin) = ProcessUserData(name, email, pass);
            IUserAuthenticationService userAuthenticationService = new UserAuthenticationServiceFactory().Create();
            
            bool userInserted = InsertUserToDb(userRegister, userAuthenticationService);
            if (!userInserted)
            {
                _registerViewModel.EmailExists = true;
                return View(_registerViewModel);
            }

            var token = AuthenticateUser(userLogin, userAuthenticationService);
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24)
            };
            Response.Cookies.Append("jwt", token.Content, cookieOptions);

            return RedirectToAction("Index", "Coins");
        }

        private bool InsertUserToDb(UserRegister userRegister, IUserAuthenticationService userAuthenticationService)
        {
            return userAuthenticationService.InsertUserFromJsonToDb(JsonConvert.SerializeObject(userRegister));
        }

        private Token AuthenticateUser(UserLogin userLogin, IUserAuthenticationService userAuthenticationService)
        {
            return userAuthenticationService.AuthenticateUserFromJson(JsonConvert.SerializeObject(userLogin));
        }

        private (UserRegister, UserLogin) ProcessUserData(string name, string email, string pass)
        {
            var userRegister = new UserRegister
            {
                Name = name,
                Email = email,
                Password = pass
            };
            var userLogin = new UserLogin
            {
                Email = email,
                Password = pass
            };
            return (userRegister, userLogin);
        }
    }
}
