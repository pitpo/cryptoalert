using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;
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


        public async Task <AllCryptoCurrenciesRootObject> GetListOfAllCryptoAsync()
        {
            var parser = new JsonParser<AllCryptoCurrenciesRootObject>();
            string httpContent = await _httpClient.GetStringAsync(_cryptoUrlProvider.ListOfAllCryptocurrenciesUrl);

            return parser.Parse(httpContent);
        }


    }
}
