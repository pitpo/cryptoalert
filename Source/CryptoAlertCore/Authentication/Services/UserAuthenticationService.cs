using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private IUserAuthenticator UserAuthenticator { get; }
        private IUserRepository UserRepository { get; }
        private ITokenVerifier TokenVerifier { get; }

        public UserAuthenticationService(IUserAuthenticator userAuthenticator, IUserRepository userCreator, ITokenVerifier tokenVerifier)
        {
            UserAuthenticator = userAuthenticator;
            UserRepository = userCreator;
            TokenVerifier = tokenVerifier;
        }

        public User GetUserFromToken(Token token)
        {
            (bool verified, string status) = TokenVerifier.VerifyToken(token);
            if (verified)
            {
                return UserRepository.GetUserFromDb(status);
            }
            return null;
        }

        public bool InsertUserFromJsonToDb(string jsonString)
        {
            return UserRepository.InsertUserFromJsonToDb(jsonString);
        }

        public Token AuthenticateUserFromJson(string jsonString)
        {
            UserLogin userLogin = UserRepository.GetLoginFromJson(jsonString);
            return UserAuthenticator.AuthenticateUser(userLogin);
        }
    }
}
