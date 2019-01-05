using System.Collections;
using System.Collections.Generic;
using CryptoAlertCore.CoinsInformation.DTO.Coins;

namespace CryptoAlertCore.Models
{
    public class UserFavoriteCoins : DbModel
    {
        public List<Coin> Coins { get; }
        public string UserEmail { get; }

        public UserFavoriteCoins(User user)
        {
            UserEmail = user.Email;
            Coins = new List<Coin>();
        }

        public void AddCoin(Coin coin)
        {
            Coins.Add(coin);
        }

    }
}