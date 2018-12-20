using System;
using System.Collections.Generic;
using System.Text;
using CryptoAlertCore.Authentication.Services;
using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.Authentication.Factories
{
    public class UserAuthenticationServiceFactory : IUserAuthenticationServiceFactory
    {
        public UserAuthenticationService Create()
        {
            ICryptoAlertConfiguration configuration = new CryptoAlertConfiguration();
            IDBRepository<User> userDbRepository = new DBRepository<User>(configuration.UsersDatabaseConnectionString);
            IParser parser = new JsonParser();
            IBCryptWrapper bCryptWrapper = new BCryptWrapper();
            IUserAuthenticator userAuthenticator = new UserAuthenticator(userDbRepository, bCryptWrapper);
            IJWTWrapper jwtWrapper = new JWTWrapper(configuration.JsonWebTokenSecret);
            return new UserAuthenticationService(userDbRepository, parser, userAuthenticator, bCryptWrapper, jwtWrapper);
        }
    }
}
