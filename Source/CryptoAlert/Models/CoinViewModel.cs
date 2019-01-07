using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
    public class CoinViewModel : PageModel
    {
        public Coin Coin { get; set; }

        private readonly ICoinsInformationService _coinsInformationService;
		private readonly ICryptoAlertConfiguration _configuration;

        public CoinViewModel(int coinId)
        {
            _coinsInformationService = new CoinInformationServiceFactory().Create();
			_configuration = new CryptoAlertConfiguration();
        }

		public bool CoinExists(int coinId)
		{
			if (coinId < 1 || coinId > _configuration.CoinLimit)
			{
				return false;
			}
			return true;
		}

		public void SetCoinInformation(int coinId)
		{
			Coin = GetCoinInformation(coinId);
		}

        private Coin GetCoinInformation(int coinId)
        {
            return _coinsInformationService.GetCoinAsync(coinId).Result;
        }
    }
}
