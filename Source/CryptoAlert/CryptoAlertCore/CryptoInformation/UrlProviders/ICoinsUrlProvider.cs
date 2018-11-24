using System;
namespace CryptoAlertCore.CryptoInformation.UrlProviders
{
    public interface ICoinsUrlProvider
    {
        string ListOfAllCoinsUrl { get; }
        string CoinByIdUrl { get; }
    }
}
