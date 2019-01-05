using CryptoAlertCore.Models;

namespace CryptoAlertCore.Authentication.Services
{
    public interface IUserAuthenticationService
    {
        User GetUserFromToken(Token token);
        bool InsertUserFromJsonToDb(string jsonString);
        Token AuthenticateUserFromJson(string jsonString);
    }
}
