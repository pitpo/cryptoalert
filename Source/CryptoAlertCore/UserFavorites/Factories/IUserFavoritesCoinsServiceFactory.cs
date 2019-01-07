using CryptoAlertCore.UserFavorites.Services;

namespace CryptoAlertCore.UserFavorites.Factories
{
	public interface IUserFavoritesCoinsServiceFactory
	{
		IUserFavoritesCoinsService Create();
	}
}
