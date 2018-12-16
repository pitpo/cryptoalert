using System.Collections.Generic;
using System.Linq;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.CoinsInformation.Factories;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CryptoAlert.WebApp.Models
{
    public class CoinsViewModel : PageModel
    {

        private ICoinsInformationService _coinsInformationService;

        public CoinsViewModel()
        {
            ICoinInformationServiceFactory coinInformationServiceFactory
                = new CoinInformationServiceFactory();
            _coinsInformationService = coinInformationServiceFactory.Create();
        }

        public List<Coin> ListOfAllCoins => _coinsInformationService.GetListOfAllCoinsAsync().Result.ToList();

        public void OnGet()
        {
            ICoinInformationServiceFactory coinInformationServiceFactory
                = new CoinInformationServiceFactory();
            _coinsInformationService = coinInformationServiceFactory.Create();
        }
    }
}
