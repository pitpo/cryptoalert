using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.UrlProviders;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task<Welcome> GetAsync(string uri)
        {
            Console.WriteLine("Started GetAsync");
            var httpClient = new HttpClient();
            Console.WriteLine("Started GetStringAsync");
            string content = await httpClient.GetStringAsync(uri);
            Console.WriteLine("Ended GetStringAsync");
                return await Task.Run(() => Welcome.FromJson(content));

        }

        private static async Task Start(){
            Welcome we = await GetAsync("https://min-api.cryptocompare.com/data/all/coinlist");
            Console.WriteLine(we);
        }

        static void Main(string[] args)
        {

            //Start().Wait();
            ICryptoUrlProvider cryptoUrlProvider = new CryptoUrlProvider(new CryptoAlertConfiguration());
            Console.WriteLine(cryptoUrlProvider.ListOfAllCryptocurriencesUrl);
   
            Console.Read();
        }
    }
}
