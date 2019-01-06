using System.Collections.Generic;
using System.IO;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.Models;
using CryptoAlertCore.UserFavorites.Repositories;
using CryptoAlertCore.UserFavorites.Services;
using FluentAssertions;
using NUnit.Framework;

namespace CryptoAlert.NUnit.Integration.UserFavorites.Services
{
	[TestFixture]
	public class UserFavoritesCoinsServiceTest
	{

		private const string DbConnectionString = "fav.db";
		private const string OneUserEmail = "user@one.com";
		private UserFavoritesCoinsRepository _userFavoritesCoinsRepository;
		private UserFavoritesCoinsService _sut;



		[SetUp]
		public void SetUp()
		{
			_userFavoritesCoinsRepository = new UserFavoritesCoinsRepository(DbConnectionString);

			_sut = new UserFavoritesCoinsService(_userFavoritesCoinsRepository);
		}


		[Test]
		public void ShouldInsertOneCoinProperly()
		{
			//Arrange
			var list = PreparedListOfCoins;

			//Act
			_sut.AddCoinToFavorites(list[0], OneUserEmail);

			//Assert
			var listFromRepo = _userFavoritesCoinsRepository.GetByKey(nameof(UserFavoriteCoins.UserEmail), OneUserEmail)
				.Coins;

			listFromRepo.Should().HaveCount(1);
		}

		[Test]
		public void ShouldInsertCollectionOfCoinsProperly()
		{
			//Arrange
			var list = PreparedListOfCoins;

			//Act
			_sut.AddCoinsToFavorites(list, OneUserEmail);

			//Assert
			var listFromRepo = _userFavoritesCoinsRepository.GetByKey(nameof(UserFavoriteCoins.UserEmail), OneUserEmail)
				.Coins;

			listFromRepo.Should().HaveCount(list.Count);
		}

		[Test]
		public void FailingTest()
		{
			PreparedListOfCoins.Should().HaveCount(10);
		}

		[TearDown]
		public void TearDown()
		{
			if (File.Exists(DbConnectionString))
			{
				File.Delete(DbConnectionString);
			}
		}

		private static List<Coin> PreparedListOfCoins => new List<Coin>{
			new Coin { Name = "Btc", Id = 1 },
			new Coin { Name = "Eth", Id = 2 },
			new Coin { Name = "LiteCoin", Id = 5 }
		};
	}
}