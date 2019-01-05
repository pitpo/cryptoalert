using System.Collections.Generic;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.Models;
using CryptoAlertCore.UserFavorites.Repositories;
using CryptoAlertCore.UserFavorites.Services;
using Moq;
using NUnit.Framework;

namespace CryptoAlert.NUnit.UserFavorites.Services
{
	[TestFixture]
	public class UserFavoritesCoinsServiceTests
	{

		private Mock<IUserFavoritesCoinsRepository> _userFavoritesCoinsRepositoryMock;
		private readonly Coin _coin = new Coin();
		private const string UserEmail = "test@test.com";

		private UserFavoritesCoinsService _sut;

		[SetUp]
		public void SetUp()
		{
			_userFavoritesCoinsRepositoryMock = new Mock<IUserFavoritesCoinsRepository>();

			_sut = new UserFavoritesCoinsService(_userFavoritesCoinsRepositoryMock.Object);
		}

		[Test]
		public void ItShouldCallUpsertOnceWhenItTryToAddCoinToRepository()
		{
			//Act
			_sut.AddCoinToFavorites(_coin, UserEmail);

			//Assert
			_userFavoritesCoinsRepositoryMock.Verify(x => x.Upsert(It.IsAny<UserFavoriteCoins>()));
		}

		[Test]
		public void ItShouldCallUpsertOnceWhenItTryToAddCoinSToRepository()
		{
			//Arrange
			List<Coin> coins = new List<Coin>();

			for (int i = 0; i < 10; i++)
			{
				coins.Add(new Coin());
			}

			//Act
			_sut.AddCoinToFavorites(_coin, UserEmail);

			//Assert
			_userFavoritesCoinsRepositoryMock.Verify(x => x.Upsert(It.IsAny<UserFavoriteCoins>()));

		}

		[Test]
		public void ItShouldCallGetFavoriteCoinsOnce()
		{
			//Arrange
			var userFavoriteCoin = new UserFavoriteCoins(UserEmail);
			_userFavoritesCoinsRepositoryMock.Setup(x => x.GetUserFavoriteCoinsByEmail(It.IsAny<string>()))
				.Returns(userFavoriteCoin);

			//Act
			_sut.GetFavoritesCoins(UserEmail);

			//Assert
			_userFavoritesCoinsRepositoryMock.Verify(x => x.GetUserFavoriteCoinsByEmail(It.IsAny<string>()));
		}

	}
}