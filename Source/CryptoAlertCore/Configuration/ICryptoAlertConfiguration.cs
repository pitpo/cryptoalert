namespace CryptoAlertCore.Configuration
{
    public interface ICryptoAlertConfiguration
    {
        string CryptoApiUrl { get;}
        string UsersDatabaseConnectionString { get; }
        string JsonWebTokenSecret { get; }
        string UserFavoritesCoinsDatabaseConnectionString { get; }
    }
}