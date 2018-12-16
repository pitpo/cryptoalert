using System;

namespace CryptoAlertCore.Authentication
{
    public interface IUserAuthenticator
    {
        bool Verify(String email, String unhashedPassword);
    }
}
