using System.Collections.Generic;
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
            return _userFavoritesCoinsRepository.GetUserFavoriteCoinsByEmail(userEmail).Coins;
        }

	    public void RemoveCoinFromFavorites(Coin coin, string userEmail)
	    {
	    }
    }
}