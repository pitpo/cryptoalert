using System;
using CryptoAlertCore.Configuration;

namespace CryptoAlertCore.CryptoInformation.UrlProviders
{
    public class CryptoUrlProvider : ICryptoUrlProvider
    {

        private readonly ICryptoAlertConfiguration _cryptoAlertConfiguration;
       
        public CryptoUrlProvider(ICryptoAlertConfiguration cryptoAlertConfiguration)
        {
            _cryptoAlertConfiguration = cryptoAlertConfiguration;
        }

        public string ListOfAllCryptocurrenciesUrl => $"{_cryptoAlertConfiguration.NewCryptoApiUrl}/public/coins";
        public string CryptocurrencyByIdUrl => $"{_cryptoAlertConfiguration.NewCryptoApiUrl}/public/coin/";
    }
}
