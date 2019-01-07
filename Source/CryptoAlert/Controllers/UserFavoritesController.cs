using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class UserFavoritesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}