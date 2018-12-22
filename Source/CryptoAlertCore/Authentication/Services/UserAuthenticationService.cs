namespace CryptoAlertCore.Authentication.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        public IUserAuthenticator UserAuthenticator { get; }
        public IUserCreator UserCreator { get; }
        public ITokenVerifier TokenVerifier { get; }

        public UserAuthenticationService(IUserAuthenticator userAuthenticator, IUserCreator userCreator, ITokenVerifier tokenVerifier)
        {
            UserAuthenticator = userAuthenticator;
            UserCreator = userCreator;
            TokenVerifier = tokenVerifier;
        }

        
    }
}
