namespace CryptoAlertCore.Authentication
{
    public interface IUserCreator
    {
        bool CreateUser(string jsonString);
    }
}
