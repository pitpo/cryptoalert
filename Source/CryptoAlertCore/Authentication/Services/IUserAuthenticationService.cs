namespace CryptoAlertCore.Authentication.Services
{
    public interface IUserAuthenticationService
    {
        IUserAuthenticator UserAuthenticator { get; }
        IUserCreator UserCreator { get; }
        ITokenVerifier TokenVerifier { get; }
    }
}
