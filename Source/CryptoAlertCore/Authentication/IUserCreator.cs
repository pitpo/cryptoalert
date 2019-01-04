namespace CryptoAlertCore.Authentication
{
    public interface IUserCreator
    {
        bool InsertUserFromJsonToDb(string jsonString);
        UserLogin GetLoginFromJson(string jsonString);
    }
}
