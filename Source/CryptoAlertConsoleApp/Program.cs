using System;
using System.Threading.Tasks;
using CryptoAlertCore.Authentication;
using CryptoAlertCore.Authentication.Factories;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.Models;

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
            if (userAuthenticationService.InsertUserFromJsonToDb("{\"Name\": \"Andrzej Duda\", \"Password\": \"lubiewkotki\", \"Email\": \"prezydent@gov.pl\"}"))
            {
                Console.WriteLine("Dudeł ma konto");
                Token token = userAuthenticationService.AuthenticateUserFromJson("{\"Email\": \"prezydent@gov.pl\", \"Password\": \"lubiewkotki\"}");
                if (token != null)
                {
                    Console.WriteLine("Dudeł istnieje i podał dobre hasło");
                    User user = userAuthenticationService.GetUserFromToken(token);
                    if (user != null)
                    {
                        Console.WriteLine("Tokenik się zgadza, mamy połączenie od " + user.Email);
                    } else
                    {
                        Console.WriteLine("Coś... coś się zepsuło");
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
