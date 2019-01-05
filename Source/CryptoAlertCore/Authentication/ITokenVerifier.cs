using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication
{
    public interface ITokenVerifier
    {
        (bool verified, string status) VerifyToken(Token token);
    }
}
