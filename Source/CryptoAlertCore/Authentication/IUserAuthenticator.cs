namespace CryptoAlertCore.Authentication
{
    public interface IUserAuthenticator
    {
        bool VerifyPassword(UserLogin userLogin);
        string AuthenticateUser(UserLogin userLogin);
    }
}
