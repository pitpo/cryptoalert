using System;
using System.Configuration;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Factories;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
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

        public static void TestDB()
        {
            IDBRepository<User> userRepository = new DBRepository<User>(ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString);
            User u1 = new User();
            u1.Email = "twojastara@dupajasia.com";
            User u2 = new User();
            u2.Email = "jakubkiermasz@pear.com";
            Console.WriteLine(userRepository.Insert(u1));
            Console.WriteLine(userRepository.Insert(u2));

            User r1 = userRepository.GetByKey<String>("Email", "jakubkiermasz@pear.com");

            r1.Name = "Dzban";
            r1.HashedPassword = "12345";

            Console.WriteLine(userRepository.Update(r1));

            User r2 = userRepository.GetByKey<String>("Email", "jakubkiermasz@pear.com");

            User r3 = userRepository.GetById(1);
            Console.Write("");
        }

        static void Main(string[] args)
        {
            //Start().Wait();
            TestDB();
            Console.Read();
        }
    }
}
