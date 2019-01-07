using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class UserController : Controller
    {
	    private readonly UserViewModel _userViewModel = new UserViewModel();

        public IActionResult Index()
        {
            return View(_userViewModel);
        }
    }
}