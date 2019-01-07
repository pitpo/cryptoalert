using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoAlertCore.CoinsInformation.DTO.Coins;

namespace CryptoAlertCore.CoinsInformation.Services
{
    public interface ICoinsInformationService
    {
        Task<IEnumerable<Coin>> GetListOfAllCoinsAsync();
        Task<Coin> GetCoinAsync(int coinId);
	    IEnumerable<Coin> GetListOfGivenCoinsIds(IEnumerable<int> coinIds);
    }
}
