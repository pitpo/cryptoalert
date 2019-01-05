using System.Diagnostics;
using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new CoinsController().Index();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
    }
}
