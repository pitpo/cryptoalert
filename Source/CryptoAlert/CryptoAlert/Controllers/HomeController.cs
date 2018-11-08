﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CryptoAlert.Models;
using CryptoAlertCore.CryptoInformation.DTO;
using System.Net.Http;

namespace CryptoAlert.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AboutAsync()
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync("https://www.cryptocompare.com/api/data/coinlist/");

            Welcome w = Welcome.FromJson(content);
            ViewData["Message"] = w.ToString();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
