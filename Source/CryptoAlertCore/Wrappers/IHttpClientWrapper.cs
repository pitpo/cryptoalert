using System.Threading.Tasks;

namespace CryptoAlertCore.Wrappers
{
    public interface IHttpClientWrapper
    {
        Task<string> GetStringAsync(string requestUri);
    }
}