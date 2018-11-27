using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coin;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.CoinsInformation.Services
{
    public class CoinsInformationService : ICoinsInformationService
    {
        private readonly ICoinsRepository _coinsRepository;
        private readonly IParser _parser;

        public CoinsInformationService(ICoinsRepository coinsRepository, IParser parser)
        {
            _coinsRepository = coinsRepository;
            _parser = parser;
        }

        public async Task <IEnumerable<Coin>> GetListOfAllCoinsAsync()
        {
            var content = await _coinsRepository.GetAllCoinsJsonObjectAsync();
            var allCoinsRootObject =  _parser.Parse<AllCoinsRootObject>(content);

            return allCoinsRootObject.Data.Coins.ToList();
        }

        public async Task<Coin> GetCoinAsync(int coinId)
        {
            var content = await _coinsRepository.GetOneCoinJsonObjectAsync(coinId);
            var oneCoinRootObject = _parser.Parse<OneCoinRootObject>(content);

            return oneCoinRootObject.Data.Coin;
        }
    }
}
