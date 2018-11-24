using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CryptoInformation.DTO.Coin;
using CryptoAlertCore.CryptoInformation.DTO.Coins;
using CryptoAlertCore.CryptoInformation.Repositories;
using CryptoAlertCore.CryptoInformation.UrlProviders;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.CryptoInformation.Services
{
    public class CryptoInformationService : ICryptoInformationService
    {
        private readonly HttpClient _httpClient;
        private readonly ICoinsRepository _coinsRepository;

        public CryptoInformationService(ICoinsRepository coinsRepository){
            _coinsRepository = coinsRepository;
            _httpClient = new HttpClient();
        }

        public async Task <IEnumerable<Coin>> GetListOfAllCoinsAsync()
        {
            var parser = new JsonParser<AllCoinsRootObject>();
            var httpContent = await _coinsRepository.GetAllCoinsJsonObjectAsync();

            var allCoinsRootObject =  parser.Parse(httpContent);
            return allCoinsRootObject.Data.Coins.ToList();
        }

        public async Task<Coin> GetCoinAsync(int coinId)
        {
            var parser = new JsonParser<OneCoinRootObject>();
            var httpContent = await _coinsRepository.GetOneCoinJsonObjectAsync(coinId);
            var oneCoinRootObject = parser.Parse(httpContent);

            return oneCoinRootObject.Data.Coin;
        }
    }
}
