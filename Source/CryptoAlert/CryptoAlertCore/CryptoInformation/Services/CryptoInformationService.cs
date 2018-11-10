using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.UrlProviders;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.CryptoInformation.Services
{
    public class CryptoInformationService : ICryptoInformationService
    {
        private readonly ICryptoUrlProvider _cryptoUrlProvider;

        public CryptoInformationService(ICryptoUrlProvider cryptoUrlProvider){
            _cryptoUrlProvider = cryptoUrlProvider;
        }

        public async Task<Dictionary<string, Datum>> GetListOfAllCryptoAsync()
        {
            Console.WriteLine("Started GetAsync");
            var httpClient = new HttpClient();
            Console.WriteLine("Started GetStringAsync");

            IParser<Welcome> parser = new JsonParser<Welcome>(); 
            string content = await httpClient.GetStringAsync(_cryptoUrlProvider.ListOfAllCryptocurriencesUrl);
            Welcome welcome = Welcome.FromJson(content);


            Dictionary<string, Datum> costam = welcome.Data;
            return costam;
        }
    }
}
