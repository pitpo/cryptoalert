using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DbRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using System;

namespace CryptoAlertCore.Authentication
{
    public class UserAuthenticator : IUserAuthenticator
    {
        private readonly IDbRepository<User> _dbRepository;
        private readonly IBCryptWrapper _bCryptWrapper;
        private readonly IJWTWrapper _jwtWrapper;
        private readonly IParser _parser;

        public UserAuthenticator(IDbRepository<User> dbRepository, IParser parser, IBCryptWrapper bCryptWrapper, IJWTWrapper jwtWrapper)
        {
            _dbRepository = dbRepository;
            _bCryptWrapper = bCryptWrapper;
            _jwtWrapper = jwtWrapper;
            _parser = parser;
        }

        public bool VerifyPassword(UserLogin userLogin)
        {
            var user = _dbRepository.GetByKey("Email", userLogin.Email);
            return _bCryptWrapper.Verify(userLogin.Password, user.HashedPassword);
        }

        public Token AuthenticateUser(UserLogin userLogin)
        {
            if (VerifyPassword(userLogin))
            {
                return _jwtWrapper.CreateToken(userLogin.Email);
            }
            return null;
        }
    }
}
