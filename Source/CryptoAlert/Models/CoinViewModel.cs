using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.CoinsInformation.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
    public class CoinViewModel : PageModel
    {

        private readonly ICoinsInformationService _coinsInformationService;

        public CoinViewModel()
        {
            _coinsInformationService = new CoinInformationServiceFactory().Create();
        }

        public Coin GetCoinInformation(int coinId)
        {
            return _coinsInformationService.GetCoinAsync(coinId).Result;
        }

        public Coin Coin;

    }
}
