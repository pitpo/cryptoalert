using System.Configuration;

namespace CryptoAlertCore.Configuration
{
    public class CryptoAlertConfiguration : ICryptoAlertConfiguration
    {
        public string CryptoApiUrl => "https://api.coinranking.com/v1";
        public string UsersDatabaseConnectionString => ConfigurationManager.ConnectionStrings["UsersDatabase"].ConnectionString;
        public string JsonWebTokenSecret => ConfigurationManager.AppSettings["JWTSecret"];

        public string UserFavoritesCoinsDatabaseConnectionString =>
            @"Filename=favorites.db";
    }
}