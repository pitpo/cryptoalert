using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class AllCryptoController : Controller
    {
        private readonly AllCryptoViewModel _allCryptoViewModel = new AllCryptoViewModel();

        public IActionResult Index()
        {
            ViewData.Add("Coins", _allCryptoViewModel.ListOfAllCoins);
            

            return View(_allCryptoViewModel);
        }
    }
}