using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.DTO.Coin;
using CryptoAlertCore.CryptoInformation.DTO.Coins;
using CryptoAlertCore.CryptoInformation.UrlProviders;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.CryptoInformation.Services
{
    public class CryptoInformationService : ICryptoInformationService
    {
        private readonly ICryptoUrlProvider _cryptoUrlProvider;
        private readonly HttpClient _httpClient;

        public CryptoInformationService(ICryptoUrlProvider cryptoUrlProvider){
            _cryptoUrlProvider = cryptoUrlProvider;
            _httpClient = new HttpClient();
        }

        public async Task <IEnumerable<Coin>> GetListOfAllCoinsAsync()
        {
            var parser = new JsonParser<AllCryptoCurrenciesRootObject>();
            var httpContent = await _httpClient.GetStringAsync(_cryptoUrlProvider.ListOfAllCryptocurrenciesUrl);

            AllCryptoCurrenciesRootObject allCryptoCurrenciesRootObject =  parser.Parse(httpContent);
            return allCryptoCurrenciesRootObject.Data.Coins.ToList();
        }

        public async Task<Coin> GetCoinAsync(int coinId)
        {
            var parser = new JsonParser<OneCoinRootObject>();
            var url = $"{_cryptoUrlProvider.CryptocurrencyByIdUrl}/{coinId}";
            var httpContent = await _httpClient.GetStringAsync(url);

            var oneCoinRootObject = parser.Parse(httpContent);

            return oneCoinRootObject.Data.Coin;
        }
    }
}
