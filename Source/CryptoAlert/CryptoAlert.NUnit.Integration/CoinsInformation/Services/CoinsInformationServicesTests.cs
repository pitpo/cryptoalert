using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.CoinsInformation.UrlProviders;
using CryptoAlertCore.Parsers;
using CryptoAlertCore.Wrappers;
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
            _parser = new JsonParser();
            _coinsRepository = new CoinsRepository(_coinsUrlProviderMock.Object, _httpClientMock.Object);
        }
    }
}