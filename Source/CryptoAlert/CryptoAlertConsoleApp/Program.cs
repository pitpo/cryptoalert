using System;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO;

namespace CryptoAlertConsoleApp
{
    class Program
    {

        public static async Task<Welcome> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            try
            {
                var content = await httpClient.GetStringAsync(uri);
//                var s = await httpClient.GetAsync(uri);
//                Console.WriteLine(s.Content);
//                return new Welcome();
                return await Task.Run(() => Welcome.FromJson(content));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static void Main(string[] args)
        {
           var obj = GetAsync("https://www.cryptocompare.com/api/data/coinlist/");
            Console.Read();
        }
    }
}
