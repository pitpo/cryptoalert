using System;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.UserFavorites.Repositories;
using CryptoAlertCore.UserFavorites.Services;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task Start()
        {
            var service = new CoinInformationServiceFactory().Create();
              
            Console.WriteLine("...");

            var result = await service.GetListOfAllCoinsAsync();

            Console.WriteLine(result);
        }

        public static void Test()
        {
            var favRepo =
                new UserFavoritesCoinsRepository(new CryptoAlertConfiguration().UserFavoritesCoinsDatabaseConnectionString);

			var favoritesService = new UserFavoritesCoinsService(favRepo);

	        var userEmailOne = "user@one.pl";
	        var userEmailTwo = "user@two.pl";

	        var btc = new Coin {Name = "BTC", Id = 1};
	        var eth = new Coin {Name = "Eth", Id = 2};

			favoritesService.AddCoinToFavorites(btc, userEmailOne);
			favoritesService.AddCoinToFavorites(eth, userEmailOne);

			favoritesService.AddCoinToFavorites(eth, userEmailTwo);

	        var one = favoritesService.GetFavoritesCoins(userEmailOne);
	        var two = favoritesService.GetFavoritesCoins(userEmailTwo);

        }

        static void Main(string[] args)
        {
            Test();
            //Start().Wait();
            Console.Read();
        }
    }
}
