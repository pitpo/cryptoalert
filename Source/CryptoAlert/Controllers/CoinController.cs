using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace CryptoAlert.WebApp.Controllers
{
    public class CoinController : Controller
    {
        public CoinController()
        {
        }

        [Route("/Coin/{coinId}")]
        public IActionResult Index(int coinId)
        {
            var coinViewModel = new CoinViewModel(coinId);
            return View(coinViewModel);
        }
    }
}
