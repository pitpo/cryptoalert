using System;
using System.Threading.Tasks;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.CoinsInformation.Factories;

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

        public static void Test()
        {
            Console.WriteLine("Przygotowuje i...");
            IUserAuthenticationServiceFactory userAuthenticationServiceFactory = new UserAuthenticationServiceFactory();
            IUserAuthenticationService userAuthenticationService = userAuthenticationServiceFactory.Create();
            Console.WriteLine("Zaczynamy!");
            if (userAuthenticationService.CreateUser("{\"Name\": \"Andrzej Duda\", \"Password\": \"lubiewkotki\", \"Email\": \"prezydent@gov.pl\"}"))
            {
                Console.WriteLine("Dudeł ma konto");
                string token = userAuthenticationService.AuthenticateUser("{\"Email\": \"prezydent@gov.pl\", \"Password\": \"lubiewkotki\"}");
                if (token != null)
                {
                    Console.WriteLine("Dudeł istnieje i podał dobre hasło");
                    (bool verified, string status) = userAuthenticationService.VerifyToken(token);
                    if (verified)
                    {
                        Console.WriteLine("Tokenik się zgadza, mamy połączenie od " + status);
                    } else
                    {
                        Console.WriteLine("Coś... coś się zepsuło: " + status);
                    }
                }
            }
            Console.WriteLine("Kończymy");
        }

        static void Main(string[] args)
        {
            Test();
            //Start().Wait();
            Console.Read();
        }
    }
}
