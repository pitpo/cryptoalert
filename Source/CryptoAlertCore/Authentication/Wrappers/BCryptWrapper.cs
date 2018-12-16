using System;

namespace CryptoAlertCore.Authentication.Wrappers
{
    class BCryptWrapper : IBCryptWrapper
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
