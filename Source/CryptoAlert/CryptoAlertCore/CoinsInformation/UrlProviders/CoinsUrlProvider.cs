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

        public string ListOfAllCoinsUrl => $"{_cryptoAlertConfiguration.NewCryptoApiUrl}/public/coins";
        public string CoinByIdUrl => $"{_cryptoAlertConfiguration.NewCryptoApiUrl}/public/coin";
    }
}
