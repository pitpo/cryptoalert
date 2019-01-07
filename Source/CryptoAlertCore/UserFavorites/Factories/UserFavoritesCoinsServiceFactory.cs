using CryptoAlertCore.Configuration;
using CryptoAlertCore.UserFavorites.Repositories;
using CryptoAlertCore.UserFavorites.Services;

namespace CryptoAlertCore.UserFavorites.Factories
{
	public class UserFavoritesCoinsServiceFactory : IUserFavoritesCoinsServiceFactory
	{
		public IUserFavoritesCoinsService Create()
		{
			ICryptoAlertConfiguration cryptoAlertConfiguration = new CryptoAlertConfiguration();
			IUserFavoritesCoinsRepository userFavoritesCoinsRepository = new UserFavoritesCoinsRepository(cryptoAlertConfiguration.UserFavoritesCoinsDatabaseConnectionString);
			return new UserFavoritesCoinsService(userFavoritesCoinsRepository);
		}
	}
}
