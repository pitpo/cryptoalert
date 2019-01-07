using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coin;
using CryptoAlertCore.CoinsInformation.DTO.Coins;
using CryptoAlertCore.CoinsInformation.Repositories;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.CoinsInformation.Services
{
    public class CoinsInformationService : ICoinsInformationService
    {
        private readonly ICoinsRepository _coinsRepository;
        private readonly IParser _parser;
		private readonly ICryptoAlertConfiguration _cryptoAlertConfiguration;

        public CoinsInformationService(ICoinsRepository coinsRepository, IParser parser, ICryptoAlertConfiguration cryptoAlertConfiguration)
        {
            _coinsRepository = coinsRepository;
            _parser = parser;
			_cryptoAlertConfiguration = cryptoAlertConfiguration;
        }

        public async Task <IEnumerable<Coin>> GetListOfAllCoinsAsync()
        {
            var content = await _coinsRepository.GetAllCoinsJsonObjectAsync();
            var allCoinsRootObject =  _parser.Parse<AllCoinsRootObject>(content);

            return allCoinsRootObject.Data.Coins.Take(_cryptoAlertConfiguration.CoinLimit).ToList();
        }

        public async Task<Coin> GetCoinAsync(int coinId)
        {
            var content = await _coinsRepository.GetOneCoinJsonObjectAsync(coinId);
            var oneCoinRootObject = _parser.Parse<OneCoinRootObject>(content);

            return oneCoinRootObject.Data.Coin;
        }
    }
}
