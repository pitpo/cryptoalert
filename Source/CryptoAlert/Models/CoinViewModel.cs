using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.Models;
using CryptoAlertCore.UserFavorites.Services;
using CryptoAlertCore.UserFavorites.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoAlert.WebApp.Models
{
    public class CoinViewModel : PageModel
    {
        public Coin Coin { get; set; }
		public bool IsLoggedIn { get; }
		public bool IsInFavorites { get; set; }

        private readonly ICoinsInformationService _coinsInformationService;
		private readonly ICryptoAlertConfiguration _configuration;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IUserAuthenticationService _userAuthenticationService;
		private readonly IUserFavoritesCoinsService _userFavoritesCoinsService;

        public CoinViewModel(int coinId)
        {
            _coinsInformationService = new CoinInformationServiceFactory().Create();
			_configuration = new CryptoAlertConfiguration();
			_httpContextAccessor = new HttpContextAccessor();
			_userAuthenticationService = new UserAuthenticationServiceFactory().Create();
			_userFavoritesCoinsService = new UserFavoritesCoinsServiceFactory().Create();
			IsLoggedIn = _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("jwt");
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
			if (IsLoggedIn)
			{
				IsInFavorites = _userFavoritesCoinsService.CheckIfCoinAlreadyInFavorites(Coin, GetLoggedInUserEmail());
			}
		}

		public void AddFavorite()
		{
			var email = GetLoggedInUserEmail();
			_userFavoritesCoinsService.AddCoinToFavorites(Coin, email);
		}

		public void RemoveFavorite()
		{
			var email = GetLoggedInUserEmail();
			_userFavoritesCoinsService.RemoveCoinFromFavorites(Coin, email);
		}

		private string GetLoggedInUserEmail()
		{
			var token = _httpContextAccessor.HttpContext.Request.Cookies["jwt"];
			return _userAuthenticationService.GetUserFromToken(new Token(token)).Email;
		}

        private Coin GetCoinInformation(int coinId)
        {
            return _coinsInformationService.GetCoinAsync(coinId).Result;
        }
    }
}
