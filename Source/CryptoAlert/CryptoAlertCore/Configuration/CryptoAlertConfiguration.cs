namespace CryptoAlertCore.Configuration
{
    public class CryptoAlertConfiguration : ICryptoAlertConfiguration
    {
        public string OldCryptoApiUrl => "https://www.cryptocompare.com/api/data";
        public string NewCryptoApiUrl => "https://min-api.cryptocompare.com/data/";
    }
}