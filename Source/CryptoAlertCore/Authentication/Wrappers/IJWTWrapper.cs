using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.Authentication.Wrappers
{
    public interface IJWTWrapper
    {
        string CreateToken(string email);
        string VerifyToken(string token);
    }
}
