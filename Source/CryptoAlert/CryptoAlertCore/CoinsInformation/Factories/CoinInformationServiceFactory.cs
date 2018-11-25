using System;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.Parsers;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.CoinsInformation.UrlProviders;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.Wrappers;

namespace CryptoAlertCore.CoinsInformation.Factories
{
    class CoinInformationServiceFactory : ICoinInformationServiceFactory
    {

        public ICoinsInformationService Create()
        {
            var parser = new JsonParser();
            var configuration = new CryptoAlertConfiguration();
            var urlProvider = new CoinsUrlProvider(configuration);
            var httpClient = new HttpClientWrapper();
            var coinsInformationRepository = new CoinsRepository(urlProvider, httpClient);

            return new CoinsInformationService(coinsInformationRepository, parser);
        }
    }
}
