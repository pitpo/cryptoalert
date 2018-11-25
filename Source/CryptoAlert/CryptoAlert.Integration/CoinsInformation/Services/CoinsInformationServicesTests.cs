using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.CoinsInformation.UrlProviders;
using CryptoAlertCore.Parsers;
using CryptoAlertCore.Wrappers;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;
using NUnit.Framework;

namespace CryptoAlert.NUnit.Integration.CoinsInformation.Services
{
    [TestFixture]
    public class CoinsInformationServicesTests
    {
        private IParser _parser;
        private ICoinsRepository _coinsRepository;
        private Mock<ICoinsUrlProvider> _coinsUrlProviderMock;
        private Mock<IHttpClientWrapper> _httpClientMock;
        private CoinsInformationService _sut;

        [SetUp]
        public void SetUp()
        {
            _httpClientMock = new Mock<IHttpClientWrapper>();
            _coinsUrlProviderMock = new Mock<ICoinsUrlProvider>();

            _parser = new JsonParser();
            _coinsRepository = new CoinsRepository(_coinsUrlProviderMock.Object, _httpClientMock.Object);

            _sut = new CoinsInformationService(_coinsRepository, _parser);
        }

        [Test]
        public void WhenProperJsonIsDownloadedIt()
        {
            //Arrange
            var urlEndpoint = "https://RANDOMENDPOINT.RANDOM/";

            _coinsUrlProviderMock.Setup(x => x.ListOfAllCoinsUrl)
                .Returns(urlEndpoint);

            _httpClientMock.Setup(x => x.GetStringAsync(urlEndpoint))
                .Returns(Task.FromResult<string>("ASf"));

            //Act
            IEnumerable<Coin> result = _sut.GetListOfAllCoinsAsync().Result;

            //Assert
            result.ToList().Count.Should().Be(50);

        }

    }
}