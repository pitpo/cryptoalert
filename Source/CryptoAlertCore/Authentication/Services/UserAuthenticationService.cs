using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        IUserAuthenticator UserAuthenticator { get; }
        IUserCreator UserCreator { get; }
        ITokenVerifier TokenVerifier { get; }

        public UserAuthenticationService(IUserAuthenticator userAuthenticator, IUserCreator userCreator, ITokenVerifier tokenVerifier)
        {
            UserAuthenticator = userAuthenticator;
            UserCreator = userCreator;
            TokenVerifier = tokenVerifier;
        }

        public User GetUserFromToken(string token)
        {
            (bool verified, string status) = TokenVerifier.VerifyToken(token);
            if (verified)
            {
                return UserCreator.GetUserFromDb(status);
            }
            return null;
        }

        public bool InsertUserFromJsonToDb(string jsonString)
        {
            return UserCreator.InsertUserFromJsonToDb(jsonString);
        }

        public string LogInUserFromJson(string jsonString)
        {
            UserLogin userLogin = UserCreator.GetLoginFromJson(jsonString);
            return UserAuthenticator.AuthenticateUser(userLogin);
        }
    }
}
