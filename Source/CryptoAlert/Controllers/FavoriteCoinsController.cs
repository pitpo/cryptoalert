using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class FavoriteCoinsController : Controller
    {
        private readonly FavoriteCoinsViewModel _favoriteCoinsViewModel = new FavoriteCoinsViewModel();

        public IActionResult Index()
        {
            ViewData.Add("Coins", _favoriteCoinsViewModel.ListOfAllFavoriteCoins);

            return View(_favoriteCoinsViewModel);
        }
    }
}