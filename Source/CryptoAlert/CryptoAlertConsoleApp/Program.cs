using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.CryptoInformation.DTO;
using CryptoAlertCore.CryptoInformation.Services;
using CryptoAlertCore.CryptoInformation.UrlProviders;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task Start(){
            var service = new CryptoInformationService(new CryptoUrlProvider(new CryptoAlertConfiguration()));
            Console.WriteLine("...");

            var result = await service.GetListOfAllCryptoAsync();

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            Start().Wait();
            Console.Read();
        }
    }
}
