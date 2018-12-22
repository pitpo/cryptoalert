using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using CryptoAlertCore.Parsers;

namespace CryptoAlertCore.Authentication
{
    public class UserCreator : IUserCreator
    {
        private readonly IParser _parser;
        private readonly IDBRepository<User> _userDbRepository;
        private readonly IBCryptWrapper _bCryptWrapper;

        public UserCreator(IParser parser, IDBRepository<User> userDbRepository, IBCryptWrapper bCryptWrapper)
        {
            _parser = parser;
            _userDbRepository = userDbRepository;
            _bCryptWrapper = bCryptWrapper;
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
    }
}
