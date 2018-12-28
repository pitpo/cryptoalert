namespace CryptoAlertCore.Authentication
{
    public interface ITokenVerifier
    {
        (bool verified, string status) VerifyToken(string token);
    }
}
