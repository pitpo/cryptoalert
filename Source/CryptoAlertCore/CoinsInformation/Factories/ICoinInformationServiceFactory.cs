using CryptoAlertCore.CoinsInformation.Services;

namespace CryptoAlertCore.CoinsInformation.Factories
{
    public interface ICoinInformationServiceFactory
    {
        ICoinsInformationService Create();
    }
}
