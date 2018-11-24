using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.Repositories;
using CryptoAlertCore.CryptoInformation.Services;
using CryptoAlertCore.CryptoInformation.UrlProviders;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task Start()
        {
            var service =
                new CryptoInformationService(new CoinsRepository(new CoinsUrlProvider(new CryptoAlertConfiguration())));
            Console.WriteLine("...");

            var result = await service.GetCoinAsync(1335);

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            Start().Wait();
            Console.Read();
        }
    }
}
