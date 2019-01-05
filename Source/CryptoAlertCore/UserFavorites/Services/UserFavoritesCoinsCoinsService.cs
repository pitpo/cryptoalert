using System.Collections.Generic;
using System.Linq;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.Models;
using CryptoAlertCore.UserFavorites.Repositories;

namespace CryptoAlertCore.UserFavorites.Services
{
    public class UserFavoritesCoinsCoinsService : IUserFavoritesCoinsService
    {
        private readonly IUserFavoritesCoinsRepository _userFavoritesCoinsRepository;

        public UserFavoritesCoinsCoinsService(IUserFavoritesCoinsRepository userFavoritesCoinsRepository)
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
        }

        public IEnumerable<Coin> GetFavoritesCoins(string userEmail)
        {
            return _userFavoritesCoinsRepository.GetFavoriteCoinsByEmail(userEmail).Coins;
        }
    }
}