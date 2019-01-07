﻿using CryptoAlert.WebApp.Models;
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
    }
}
