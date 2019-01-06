using System.Collections.Generic;
using System.IO;
using System.Linq;
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
		private const string FirstUserEmail = "user@one.com";
		private const string SecondUserEmail = "user@two.com";
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
			_sut.AddCoinToFavorites(list[0], FirstUserEmail);

			//Assert
			var listFromRepo = _userFavoritesCoinsRepository.GetByKey(nameof(UserFavoriteCoins.UserEmail), FirstUserEmail)
				.Coins;

			listFromRepo.Should().HaveCount(1);
		}

		[Test]
		public void ShouldInsertCollectionOfCoinsProperly()
		{
			//Arrange
			var list = PreparedListOfCoins;

			//Act
			_sut.AddCoinsToFavorites(list, FirstUserEmail);

			//Assert
			var listFromRepo = _userFavoritesCoinsRepository.GetByKey(nameof(UserFavoriteCoins.UserEmail), FirstUserEmail)
				.Coins;

			listFromRepo.Should().HaveCount(list.Count);
		}

		[TestCase(2)]
		[TestCase(3)]
		[TestCase(10)]
		public void ItShouldNotInsertTheSameCoinToFavorites(int numberOfInserts)
		{
			//Arrange
			var list = PreparedListOfCoins;
			var oneCoin = list[0];

			//Act
			for (int i = 0; i < numberOfInserts; ++i)
			{
				_sut.AddCoinToFavorites(oneCoin, FirstUserEmail);
			}

			//Assert
			var listFromRepo = _userFavoritesCoinsRepository.GetByKey(nameof(UserFavoriteCoins.UserEmail), FirstUserEmail)
				.Coins;

			listFromRepo.Should().HaveCount(1);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(7)]
		public void ItShouldRemoveOneCoinProperly(int numberOfRemoves)
		{
			//Arrange
			var list = PreparedListOfCoins;
			_sut.AddCoinsToFavorites(list, FirstUserEmail);

			//Act
			for (int i = 0; i < numberOfRemoves; i++)
			{
				_sut.RemoveCoinFromFavorites(list[0], FirstUserEmail);
			}

			//Assert
			var listFromRepo = _userFavoritesCoinsRepository.GetByKey(nameof(UserFavoriteCoins.UserEmail), FirstUserEmail)
				.Coins;
			listFromRepo.Should().HaveCount(2);

			_sut.GetFavoritesCoins(FirstUserEmail).Should().HaveCount(2);
			var listOfId = _sut.GetFavoritesCoins(FirstUserEmail).Select(x => x.Id).ToList();
			listOfId.Should().HaveCount(list.Count - 1);
			listOfId.Should().NotContain(list[0].Id);

			for (int i = 1; i < list.Count; i++)
			{
				listOfId.Should().Contain(list[i].Id);
			}
		}

		[Test]
		public void ItShouldNotAddCoinsToFavoritesForAnotherUser()
		{
			//Act
			_sut.AddCoinToFavorites(PreparedListOfCoins[0], FirstUserEmail);
			
			//Assert
			_sut.GetFavoritesCoins(SecondUserEmail).Should().BeEmpty();
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