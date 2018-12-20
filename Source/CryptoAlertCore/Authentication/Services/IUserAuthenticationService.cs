using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.Authentication.Services
{
    public interface IUserAuthenticationService
    {
        bool CreateUser(String jsonString);
        String AuthenticateUser(String jsonString);
        (bool verified, String status) VerifyToken(String token);
    }
}
