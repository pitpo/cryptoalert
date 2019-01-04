using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.CoinsInformation.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
    public class CoinViewModel : PageModel
    {
        public Coin Coin { get; }

        private readonly ICoinsInformationService _coinsInformationService;

        public CoinViewModel(int coinId)
        {
            _coinsInformationService = new CoinInformationServiceFactory().Create();
            Coin = GetCoinInformation(coinId);
        }

        private Coin GetCoinInformation(int coinId)
        {
            return _coinsInformationService.GetCoinAsync(coinId).Result;
        }
    }
}
