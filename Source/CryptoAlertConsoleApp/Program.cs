using System;
using System.Configuration;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using LiteDB;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task Start()
        {
            var service = new CoinInformationServiceFactory().Create();
              
            Console.WriteLine("...");

            var result = await service.GetListOfAllCoinsAsync();

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            //Start().Wait();
            Console.Read();
        }
    }
}
