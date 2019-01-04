using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication.Services
{
    public interface IUserAuthenticationService
    {
        User GetUserFromToken(string token);
        bool InsertUserFromJsonToDb(string jsonString);
        string LogInUserFromJson(string jsonString);
    }
}
