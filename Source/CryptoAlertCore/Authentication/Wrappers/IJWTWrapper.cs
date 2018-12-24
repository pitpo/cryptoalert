namespace CryptoAlertCore.Authentication.Wrappers
{
    public interface IJWTWrapper
    {
        string CreateToken(string email);
        string GetDecodedToken(string token);
    }
}
