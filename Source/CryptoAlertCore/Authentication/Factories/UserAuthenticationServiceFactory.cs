using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.Authentication.Factories
{
    public class UserAuthenticationServiceFactory : IUserAuthenticationServiceFactory
    {
        public IUserAuthenticationService Create()
        {
            ICryptoAlertConfiguration configuration = new CryptoAlertConfiguration();
            IDBRepository<User> userDbRepository = new DBRepository<User>(configuration.UsersDatabaseConnectionString);
            IParser parser = new JsonParser();
            IBCryptWrapper bCryptWrapper = new BCryptWrapper();
            IJWTWrapper jwtWrapper = new JWTWrapper(configuration.JsonWebTokenSecret);
            IUserAuthenticator userAuthenticator = new UserAuthenticator(userDbRepository, parser, bCryptWrapper, jwtWrapper);
            IUserCreator userCreator = new UserCreator(parser, userDbRepository, bCryptWrapper);
            ITokenVerifier tokenVerifier = new TokenVerifier(jwtWrapper, parser);
            return new UserAuthenticationService(userAuthenticator, userCreator, tokenVerifier);
        }
    }
}
