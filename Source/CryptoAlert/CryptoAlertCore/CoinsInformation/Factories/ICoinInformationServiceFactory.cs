using CryptoAlertCore.CoinsInformation.Services;

namespace CryptoAlertCore.CoinsInformation.Factories
{
    interface ICoinInformationServiceFactory
    {
        ICoinsInformationService Create();
    }
}
