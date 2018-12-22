using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;
using System;

namespace CryptoAlertCore.Authentication
{
    public class UserAuthenticator : IUserAuthenticator
    {
        private readonly IDBRepository<User> _dbRepository;
        private readonly IBCryptWrapper _bCryptWrapper;
        private readonly IJWTWrapper _jwtWrapper;
        private readonly IParser _parser;

        public UserAuthenticator(IDBRepository<User> dbRepository, IParser parser, IBCryptWrapper bCryptWrapper, IJWTWrapper jwtWrapper)
        {
            _dbRepository = dbRepository;
            _bCryptWrapper = bCryptWrapper;
            _jwtWrapper = jwtWrapper;
            _parser = parser;
        }

        public bool VerifyPassword(string email, string unhashedPassword)
        {
            var user = _dbRepository.GetByKey<String>("Email", email);
            return _bCryptWrapper.Verify(unhashedPassword, user.HashedPassword);
        }

        public string AuthenticateUser(string jsonString)
        {
            dynamic auth = _parser.Parse<dynamic>(jsonString);
            if (auth["Email"] != null && auth["Password"] != null)
            {
                if (VerifyPassword(auth["Email"].Value, auth["Password"].Value))
                {
                    return _jwtWrapper.CreateToken(auth["Email"].Value);
                }
            }
            return null;
        }
    }
}
