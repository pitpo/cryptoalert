using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.Configuration;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using JWT;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.Authentication.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IDBRepository<User> _userDbRepository;
        private readonly IParser _parser;
        private readonly IUserAuthenticator _userAuthenticator;
        private readonly IBCryptWrapper _bCryptWrapper;
        private readonly IJWTWrapper _jwtWrapper;

        public UserAuthenticationService(IDBRepository<User> userDbRepository, IParser parser, IUserAuthenticator userAuthenticator, IBCryptWrapper bCryptWrapper, IJWTWrapper jwtWrapper)
        {
            _userDbRepository = userDbRepository;
            _parser = parser;
            _userAuthenticator = userAuthenticator;
            _bCryptWrapper = bCryptWrapper;
            _jwtWrapper = jwtWrapper;
        }

        public string AuthenticateUser(string jsonString)
        {
            dynamic auth = _parser.Parse<dynamic>(jsonString);
            if (auth["Email"] != null && auth["Password"] != null) {
                if (_userAuthenticator.Verify(auth["Email"].Value, auth["Password"].Value))
                {
                    return _jwtWrapper.CreateToken(auth["Email"].Value);
                }
            }
            return null;
        }

        public bool CreateUser(string jsonString)
        {
            dynamic user = _parser.Parse<dynamic>(jsonString);
            if (user["Name"] != null && user["Email"] != null && user["Password"] != null)
            {
                if (_userDbRepository.GetByKey<string>("Email", user["Email"].Value) == null)
                {
                    User userDb = new User()
                    {
                        Name = user["Name"].Value,
                        Email = user["Email"].Value,
                        HashedPassword = _bCryptWrapper.HashPassword(user["Password"].Value),
                    };
                    return _userDbRepository.Insert(userDb);
                }
            }
            return false;
        }

        public (bool verified, string status) VerifyToken(string token)
        {
            try
            {
                string tokenJson = _jwtWrapper.VerifyToken(token);
                dynamic tokenDeserialized = _parser.Parse<dynamic>(tokenJson);
                return (verified: true, status: tokenDeserialized["usr"].Value);
            }
            catch (TokenExpiredException)
            {
                return (verified: false, status: "Token has expired");
            }
            catch (SignatureVerificationException)
            {
                return (verified: false, status: "Token has invalid signature");
            }
        }
    }
}
