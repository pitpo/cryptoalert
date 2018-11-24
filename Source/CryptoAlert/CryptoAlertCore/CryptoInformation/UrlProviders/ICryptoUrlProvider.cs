using System;
namespace CryptoAlertCore.CryptoInformation.UrlProviders
{
    public interface ICryptoUrlProvider
    {
        string ListOfAllCryptocurrenciesUrl { get; }
        string CryptocurrencyByIdUrl { get; }
    }
}
