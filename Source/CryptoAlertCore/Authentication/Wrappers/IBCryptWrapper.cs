using System;

namespace CryptoAlertCore.Authentication.Wrappers
{
    public interface IBCryptWrapper
    {
        String HashPassword(string password);
        bool Verify(string password, string hashedPassword);
    }
}
