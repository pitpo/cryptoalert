using CryptoAlertCore.DbRepository;
using CryptoAlertCore.Models;

namespace CryptoAlertCore.UserFavorites.Repositories
{
    public interface IUserFavoritesCoinsRepository : IDbRepository<UserFavoriteCoins>
    {
        void Upsert(UserFavoriteCoins userFavoriteCoins);
        UserFavoriteCoins GetFavoriteCoinsByEmail(string userEmail);
    }
}