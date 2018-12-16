using System;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.CoinsInformation.UrlProviders;
using CryptoAlertCore.Wrappers;
using Moq;
using NUnit.Framework;

namespace CryptoAlert.NUnit.CoinsInformation.Repositories
{
    [TestFixture]
    public class CoinsRepositoryTests
    {
        private Mock<ICoinsUrlProvider> _coinsUrlProviderMock;
        private Mock<IHttpClientWrapper> _httpClientMock;
        private CoinsRepository _sut;
        private readonly string urlEndpoint = "https://endpoint.endpoint";

        [SetUp]
        public void SetUp()
        {
            _coinsUrlProviderMock = new Mock<ICoinsUrlProvider>();
            _httpClientMock = new Mock<IHttpClientWrapper>();

            _coinsUrlProviderMock.Setup(x => x.ListOfAllCoinsUrl)
                .Returns(urlEndpoint);
            _coinsUrlProviderMock.Setup(x => x.CoinByIdUrl)
                .Returns(urlEndpoint);
            _httpClientMock.Setup(x => x.GetStringAsync(urlEndpoint))
                .Returns(Task.FromResult<string>(string.Empty));

            _sut = new CoinsRepository(_coinsUrlProviderMock.Object, _httpClientMock.Object);
        }


        [Test]
#pragma warning disable AV1755 // Name of async method should end with Async or TaskAsync
        public async Task ItShouldCallHttpClientWithProperUrlWhenGetAllCoinsIsCalled()
        {
            //Act
            await _sut.GetAllCoinsJsonObjectAsync();

            //Assert
            _httpClientMock.Verify(x => x.GetStringAsync(urlEndpoint), Times.Once);
        }

        [Test]
        public async Task ItShouldCallHttpClientWithProperUrlOnceWhenGetOneCoinIsCalled()
        {
            //Act
            await _sut.GetOneCoinJsonObjectAsync(new Random().Next());
            //Assert
            _httpClientMock.Verify(x => x.GetStringAsync(It.IsAny<string>()), Times.Once);
        }


#pragma warning restore AV1755 // Name of async method should end with Async or TaskAsync
    }
}