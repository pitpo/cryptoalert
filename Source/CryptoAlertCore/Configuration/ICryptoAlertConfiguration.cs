namespace CryptoAlertCore.Configuration
{
    public interface ICryptoAlertConfiguration
    {
        string CryptoApiUrl { get;}
        string UsersConnectionString { get; }
    }
}