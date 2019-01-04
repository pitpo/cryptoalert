using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication.Wrappers
{
    public interface IJWTWrapper
    {
        Token CreateToken(string email);
        string GetDecodedToken(Token token);
    }
}
