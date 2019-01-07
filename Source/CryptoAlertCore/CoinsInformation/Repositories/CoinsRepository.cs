using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.UrlProviders;
using CryptoAlertCore.Wrappers;

namespace CryptoAlertCore.CoinsInformation.Repositories
{
    public class CoinsRepository : ICoinsRepository
    {
        private readonly IHttpClientWrapper _httpClient;
        private readonly ICoinsUrlProvider _coinsUrlProvider;

        public CoinsRepository(ICoinsUrlProvider coinsUrlProvider, IHttpClientWrapper httpClient)
        {
            _coinsUrlProvider = coinsUrlProvider;
            _httpClient = httpClient;
        }

        public async Task<string> GetAllCoinsJsonObjectAsync()
        {
            return await _httpClient.GetStringAsync(_coinsUrlProvider.ListOfAllCoinsUrl);
        }

        public async Task<string> GetOneCoinJsonObjectAsync(int coinId)
        {
            var url = $"{_coinsUrlProvider.CoinByIdUrl}/{coinId}";
            return await _httpClient.GetStringAsync(url);
        }
    }
}