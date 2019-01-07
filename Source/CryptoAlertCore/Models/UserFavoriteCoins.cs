using System.Collections;
using System.Collections.Generic;
using CryptoAlertCore.CoinsInformation.DTO.Coins;

namespace CryptoAlertCore.Models
{
    public class UserFavoriteCoins : DbModel
    {
        public List<Coin> Coins { get; set; }
        public string UserEmail { get; set; }

        public UserFavoriteCoins(string userEmail)
        {
            UserEmail = userEmail;
            Coins = new List<Coin>();
        }

        public UserFavoriteCoins()
        {

        }

        public void AddCoin(Coin coin)
        {
            Coins.Add(coin);
        }

    }
}