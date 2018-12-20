using CryptoAlertCore.Authentication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.Authentication.Factories
{
    public interface IUserAuthenticationServiceFactory
    {
        UserAuthenticationService Create();
    }
}
