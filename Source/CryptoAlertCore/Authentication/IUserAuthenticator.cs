using System;

namespace CryptoAlertCore.Authentication
{
    public interface IUserAuthenticator
    {
        bool VerifyPassword(String email, String unhashedPassword);
        string AuthenticateUser(String jsonString);
    }
}
