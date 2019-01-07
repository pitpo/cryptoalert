using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.Models;
using CryptoAlertCore.UserFavorites.Factories;
using CryptoAlertCore.UserFavorites.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CryptoAlert.WebApp.Models
{
    public class FavoriteCoinsViewModel : PageModel
    {
		private IUserFavoritesCoinsService _userFavoritesCoinsService;
		private readonly IUserAuthenticationService _userAuthenticationService;
		private string _userEmail;

		public FavoriteCoinsViewModel()
		{
			IUserFavoritesCoinsServiceFactory userFavoritesCoinsServiceFactory
				= new UserFavoritesCoinsServiceFactory();
			_userFavoritesCoinsService = userFavoritesCoinsServiceFactory.Create();

			IUserAuthenticationServiceFactory userAuthenticationServiceFactory
				= new UserAuthenticationServiceFactory();
			_userAuthenticationService = userAuthenticationServiceFactory.Create();

			var token = new HttpContextAccessor().HttpContext.Request.Cookies["jwt"];
			_userEmail = _userAuthenticationService.GetUserFromToken(new Token(token)).Email;
		}

		public List<Coin> ListOfAllFavoriteCoins => _userFavoritesCoinsService.GetFavoritesCoins(_userEmail).ToList();

		public void OnGet()
		{
			IUserFavoritesCoinsServiceFactory userFavoritesCoinsServiceFactory
				= new UserFavoritesCoinsServiceFactory();
			_userFavoritesCoinsService = userFavoritesCoinsServiceFactory.Create();
			_userEmail = new HttpContextAccessor().HttpContext.Request.Cookies["jwt"];
		}

	}
}