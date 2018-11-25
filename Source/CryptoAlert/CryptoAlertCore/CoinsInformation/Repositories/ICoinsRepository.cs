using System.Threading.Tasks;

namespace CryptoAlertCore.CoinsInformation.Repositories
{
    public interface ICoinsRepository
    {
        Task<string> GetAllCoinsJsonObjectAsync();
        Task<string> GetOneCoinJsonObjectAsync(int coinId);
    }
}