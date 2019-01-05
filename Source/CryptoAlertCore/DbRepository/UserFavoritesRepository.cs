using CryptoAlertCore.Models;

namespace CryptoAlertCore.DbRepository
{
    public class UserFavoritesRepository : DbRepository<UserFavoriteCoins>
    {
        public UserFavoritesRepository(string connectionString) : base(connectionString)
        {
        }

    }
}