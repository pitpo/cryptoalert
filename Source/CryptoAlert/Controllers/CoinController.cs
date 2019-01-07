using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoAlert.WebApp.Controllers
{
    public class CoinController : Controller
    {

        [Route("/Coin/{coinId}")]
        public IActionResult Index(int coinId)
        {
            var coinViewModel = new CoinViewModel(coinId);
			if (coinViewModel.CoinExists(coinId))
			{
				coinViewModel.SetCoinInformation(coinId);
				return View(coinViewModel);
			}
			return RedirectToAction("Error", "Home");
        }

		[Route("/Coin/AddFavorite/{coinId}")]
		public IActionResult AddFavorite(int coinId)
		{
			var coinViewModel = new CoinViewModel(coinId);
			coinViewModel.SetCoinInformation(coinId);
			coinViewModel.AddFavorite();
			return RedirectToAction(coinId.ToString());
		}

		[Route("/Coin/RemoveFavorite/{coinId}")]
		public IActionResult RemoveFavorite(int coinId)
		{
			var coinViewModel = new CoinViewModel(coinId);
			coinViewModel.SetCoinInformation(coinId);
			coinViewModel.RemoveFavorite();
			return RedirectToAction(coinId.ToString());
		}
	}
}
