using System.Collections.Generic;
using System.Linq;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.Models;
using CryptoAlertCore.UserFavorites.Repositories;

namespace CryptoAlertCore.UserFavorites.Services
{
	public class UserFavoritesCoinsService : IUserFavoritesCoinsService
	{
		private readonly IUserFavoritesCoinsRepository _userFavoritesCoinsRepository;

		public UserFavoritesCoinsService(IUserFavoritesCoinsRepository userFavoritesCoinsRepository)
		{
			this._userFavoritesCoinsRepository = userFavoritesCoinsRepository;
		}

		public void AddCoinToFavorites(Coin coin, string userEmail)
		{
			var userFavoritesCoin = new UserFavoriteCoins(userEmail);
			userFavoritesCoin.AddCoin(coin);
			_userFavoritesCoinsRepository.Upsert(userFavoritesCoin);
		}

		public void AddCoinsToFavorites(IEnumerable<Coin> coins, string userEmail)
		{
			var userFavoritesCoins = new UserFavoriteCoins(userEmail);
			userFavoritesCoins.Coins.AddRange(coins);
			_userFavoritesCoinsRepository.Upsert(userFavoritesCoins);
		}

		public IEnumerable<Coin> GetFavoritesCoins(string userEmail)
		{
			if (_userFavoritesCoinsRepository.GetUserFavoriteCoinsByEmail(userEmail) == null)
			{
				return new List<Coin>();
			}
			return _userFavoritesCoinsRepository.GetUserFavoriteCoinsByEmail(userEmail).Coins;
		}

		public void RemoveCoinFromFavorites(Coin coinToRemove, string userEmail)
		{
			var favoritesCoins = GetFavoritesCoins(userEmail).ToList();
			favoritesCoins.RemoveAll(coin => coin.Id == coinToRemove.Id);

			var userFavoritesCoins = new UserFavoriteCoins(userEmail) { Coins = favoritesCoins };

			_userFavoritesCoinsRepository.Override(userFavoritesCoins);
		}

		public bool CheckIfCoinAlreadyInFavorites(Coin coin, string userEmail)
		{
			var favoriteCoins = GetFavoritesCoins(userEmail).Where(coinToFind => coinToFind != null).Select(coinToFind => coinToFind.Id);
			return favoriteCoins.Contains(coin.Id);
		}
	}
}