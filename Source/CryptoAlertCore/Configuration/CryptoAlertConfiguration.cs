using System.Configuration;

namespace CryptoAlertCore.Configuration
{
    public class CryptoAlertConfiguration : ICryptoAlertConfiguration
    {
        public string CryptoApiUrl => "https://api.coinranking.com/v1";
        public string UsersConnectionString => ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
    }
}