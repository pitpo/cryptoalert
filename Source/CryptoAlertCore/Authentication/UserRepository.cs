﻿using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DbRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.Authentication
{
    public class UserRepository : IUserRepository
    {
        private readonly IParser _parser;
        private readonly IDbRepository<User> _userDbRepository;
        private readonly IBCryptWrapper _bCryptWrapper;

        public UserRepository(IParser parser, IDbRepository<User> userDbRepository, IBCryptWrapper bCryptWrapper)
        {
            _parser = parser;
            _userDbRepository = userDbRepository;
            _bCryptWrapper = bCryptWrapper;
        }

        public bool InsertUserFromJsonToDb(string jsonString)
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

        public UserLogin GetLoginFromJson(string jsonString)
        {
            return _parser.Parse<UserLogin>(jsonString);
        }

        public User GetUserFromDb(string email)
        {
            return _userDbRepository.GetByKey<string>("Email", email);
        }
    }
}
