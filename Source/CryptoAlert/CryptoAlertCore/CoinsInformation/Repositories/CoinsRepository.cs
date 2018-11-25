using System.Net.Http;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.UrlProviders;

namespace CryptoAlertCore.CoinsInformation.Repositories
{
    public class CoinsRepository : ICoinsRepository
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ICoinsUrlProvider _coinsUrlProvider;

        public CoinsRepository(ICoinsUrlProvider coinsUrlProvider)
        {
            _coinsUrlProvider = coinsUrlProvider;
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