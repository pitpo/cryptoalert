using System.Collections.Generic;
using System.Linq;
using CryptoAlertCore.CoinsInformation.DTO.Coin;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.Parsers;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using Data = CryptoAlertCore.CoinsInformation.DTO.Coins.Data;

namespace CryptoAlert.NUnit.CoinsInformation.Services
{
    [TestFixture]
    public class CoinsInformationServiceTests
    {
        private Mock<IParser> _parserMock;
        private Mock<ICoinsRepository> _coinsRepositoryMock;
		private Mock<ICryptoAlertConfiguration> _cryptoAlertConfigurationMock;
        private CoinsInformationService _sut;

        [SetUp]
        public void SetUp()
        {
            _parserMock = new Mock<IParser>();
            _coinsRepositoryMock = new Mock<ICoinsRepository>();
			_cryptoAlertConfigurationMock = new Mock<ICryptoAlertConfiguration>();
            _sut = new CoinsInformationService(_coinsRepositoryMock.Object, _parserMock.Object, _cryptoAlertConfigurationMock.Object);
        }

        [Test]
        public void WhenParserReturnProperAllCoinsRootObjectItShouldReturnProperCollectionsOfCoins()
        {
            //Arrange
            var expected = new List<Coin>();

            for (var i = 0; i < 10; ++i)
            {
                expected.Add(new Coin());
            }

            var allCoinsRootObject = new AllCoinsRootObject
            {
                Data = new Data
                {
                    Coins = expected.ToArray()
                }
            };

            _parserMock.Setup(x => x.Parse<AllCoinsRootObject>(It.IsAny<string>()))
                .Returns(allCoinsRootObject);
			_cryptoAlertConfigurationMock.Setup(x => x.CoinLimit).Returns(5000);

            //Act
            List<Coin> result = _sut.GetListOfAllCoinsAsync().Result.ToList();

            //Assert
           CollectionAssert.AreEqual(expected, result);

        }

        [Test]
        public void WhenParserReturnsProperOneCoinRootObjectItShouldReturnProperCoin()
        {
            //Arrange
            var coinId = 1335;

            var expected = new Coin
            {
                Id = coinId,
                Change = (float) 0.25,
                Name = "BTC"
            };
            var oneCoinRootObject = new OneCoinRootObject
            {
                Data = new CryptoAlertCore.CoinsInformation.DTO.Coin.Data
                {
                    Coin = expected
                }
            };

            _parserMock.Setup(x => x.Parse<OneCoinRootObject>(It.IsAny<string>()))
                .Returns(oneCoinRootObject);

            //Act
            var result = _sut.GetCoinAsync(coinId).Result;

            //Assert
            result.Should().Be(expected);
        }

    }
}