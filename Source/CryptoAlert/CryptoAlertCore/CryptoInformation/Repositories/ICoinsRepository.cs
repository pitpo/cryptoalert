using System.Threading.Tasks;

namespace CryptoAlertCore.CryptoInformation.Repositories
{
    public interface ICoinsRepository
    {
        Task<string> GetAllCoinsJsonObjectAsync();
        Task<string> GetOneCoinJsonObjectAsync(int coinId);
    }
}