using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlert.WebApp.Models;
using Microsoft.AspNetCore.Mvc;


namespace CryptoAlert.WebApp.Controllers
{
    public class CoinController : Controller
    {
        private CoinViewModel _coinViewModel;
        public CoinController()
        {
            _coinViewModel = new CoinViewModel();
        }

        [Route("/Coin/{coinId}")]
        public IActionResult Index(int coinId)
        {

            return View(_coinViewModel);
        }
    }
}
