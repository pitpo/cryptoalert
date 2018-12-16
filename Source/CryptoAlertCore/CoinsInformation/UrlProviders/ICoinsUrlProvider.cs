namespace CryptoAlertCore.CoinsInformation.UrlProviders
{
    public interface ICoinsUrlProvider
    {
        string ListOfAllCoinsUrl { get; }
        string CoinByIdUrl { get; }
    }
}
