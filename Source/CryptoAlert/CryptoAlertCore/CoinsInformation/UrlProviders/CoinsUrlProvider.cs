using CryptoAlertCore.Configuration;

namespace CryptoAlertCore.CoinsInformation.UrlProviders
{
    public class CoinsUrlProvider : ICoinsUrlProvider
    {

        private readonly ICryptoAlertConfiguration _cryptoAlertConfiguration;
       
        public CoinsUrlProvider(ICryptoAlertConfiguration cryptoAlertConfiguration)
        {
            _cryptoAlertConfiguration = cryptoAlertConfiguration;
        }

        public string ListOfAllCoinsUrl => $"{_cryptoAlertConfiguration.CryptoApiUrl}/public/coins";
        public string CoinByIdUrl => $"{_cryptoAlertConfiguration.CryptoApiUrl}/public/coin";
    }
}
