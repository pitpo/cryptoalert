using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class CoinsController : Controller
    {
        private readonly CoinsViewModel _coinsViewModel = new CoinsViewModel();

        public IActionResult Index()
        {
            ViewData.Add("Coins", _coinsViewModel.ListOfAllCoins);

            return View(_coinsViewModel);
        }
    }
}