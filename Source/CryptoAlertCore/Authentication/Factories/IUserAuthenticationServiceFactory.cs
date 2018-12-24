using CryptoAlertCore.Authentication.Services;

namespace CryptoAlertCore.Authentication.Factories
{
    public interface IUserAuthenticationServiceFactory
    {
        IUserAuthenticationService Create();
    }
}
