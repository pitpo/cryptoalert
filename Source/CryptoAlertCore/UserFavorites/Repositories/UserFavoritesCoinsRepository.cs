﻿using System.Collections.Generic;
using System.Linq;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.DbRepository;
using CryptoAlertCore.Models;
using LiteDB;

namespace CryptoAlertCore.UserFavorites.Repositories
{
    public class UserFavoritesCoinsRepository : DbRepository<UserFavoriteCoins>, IUserFavoritesCoinsRepository
    {
        public UserFavoritesCoinsRepository(string connectionString) : base(connectionString)
        {
        }

        public override bool Insert(UserFavoriteCoins userFavoriteCoins)
        {
            if (CheckIfAlreadyExists(userFavoriteCoins))
            {
                return false;
            }

            using (LiteRepository db = new LiteRepository(base.ConnectionString))
            {
                db.Insert(userFavoriteCoins);
            }
            return true;
        }

        public void Upsert(UserFavoriteCoins userFavoriteCoins)
        {
            if (CheckIfAlreadyExists(userFavoriteCoins))
            {
                var currentUser = GetUserFavoriteCoinsByEmail(userFavoriteCoins.UserEmail);
                userFavoriteCoins.Id = currentUser.Id;

	            userFavoriteCoins.Coins.AddRange(currentUser.Coins);
	            userFavoriteCoins.Coins = RemoveDuplicates(userFavoriteCoins.Coins).ToList();
            }

            using (LiteRepository db = new LiteRepository(base.ConnectionString))
            {
                db.Upsert(userFavoriteCoins);
            }
        }

	    public void Override(UserFavoriteCoins userFavoriteCoins)
	    {
		    if (CheckIfAlreadyExists(userFavoriteCoins))
		    {
			    var currentUser = GetUserFavoriteCoinsByEmail(userFavoriteCoins.UserEmail);

			    using (LiteRepository db = new LiteRepository(base.ConnectionString))
			    {
				    db.Delete<UserFavoriteCoins>(currentUser.Id);
			    }
			}

			Insert(userFavoriteCoins);
	    }
	    public UserFavoriteCoins GetUserFavoriteCoinsByEmail(string userEmail)
	    {
		    return base.GetByKey(nameof(UserFavoriteCoins.UserEmail), userEmail);
	    }

		private bool CheckIfAlreadyExists(UserFavoriteCoins obj)
        {
            return base.GetByKey(nameof(UserFavoriteCoins.UserEmail), obj.UserEmail) != null;
        }

	    private IEnumerable<Coin> RemoveDuplicates(IEnumerable<Coin> coins) => coins.GroupBy(coin => coin.Id)
		    .Select(group => @group.First());
    }
}