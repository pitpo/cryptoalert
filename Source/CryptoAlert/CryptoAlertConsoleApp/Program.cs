using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.CoinsInformation.Services;
using CryptoAlertCore.CoinsInformation.UrlProviders;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.Parsers;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task Start()
        {
            var service =
                new CoinsInformationService(new CoinsRepository(new CoinsUrlProvider(new CryptoAlertConfiguration())), new JsonParser());
            Console.WriteLine("...");

            var result = await service.GetListOfAllCoinsAsync();

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            Start().Wait();
            Console.Read();
        }
    }
}
