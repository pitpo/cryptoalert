using Microsoft.AspNetCore.Mvc;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Authentication;

namespace CryptoAlert.WebApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public void OnPost()
        {
            var userLogin = new UserLogin
            {
                Email = Request.Form["email"],
                Password = Request.Form["pass"]
            };
            IUserAuthenticationService userAuthenticationService = new UserAuthenticationServiceFactory().Create();
            //userAuthenticationService.AuthenticateUserFromJson(Json(userLogin).);
        }
    }
}
