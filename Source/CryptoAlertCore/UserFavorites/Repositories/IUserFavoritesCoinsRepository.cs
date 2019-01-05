using CryptoAlertCore.DbRepository;
using CryptoAlertCore.Models;

namespace CryptoAlertCore.UserFavorites.Repositories
{
    public interface IUserFavoritesCoinsRepository : IDbRepository<UserFavoriteCoins>
    {
        void Upsert(UserFavoriteCoins userFavoriteCoins);
	    void Override(UserFavoriteCoins userFavoriteCoins);
        UserFavoriteCoins GetUserFavoriteCoinsByEmail(string userEmail);
    }
}