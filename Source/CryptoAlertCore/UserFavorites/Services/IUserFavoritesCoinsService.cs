using System.Collections.Generic;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.Models;

namespace CryptoAlertCore.UserFavorites.Services
{
    public interface IUserFavoritesCoinsService
    {
        void AddCoinToFavorites(Coin coin, string userEmail);
        void AddCoinsToFavorites(IEnumerable<Coin> coins, string userEmail);
        IEnumerable<Coin> GetFavoritesCoins(string userEmail);
    }
}