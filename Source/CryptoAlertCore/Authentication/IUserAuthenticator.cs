using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication
{
    public interface IUserAuthenticator
    {
        bool VerifyPassword(UserLogin userLogin);
        Token AuthenticateUser(UserLogin userLogin);
    }
}
