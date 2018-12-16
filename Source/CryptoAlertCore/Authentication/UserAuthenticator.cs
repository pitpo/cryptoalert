using CryptoAlertCore.Authentication.Wrappers;
using CryptoAlertCore.DBRepository;
using CryptoAlertCore.Models;
using System;

namespace CryptoAlertCore.Authentication
{
    public class UserAuthenticator : IUserAuthenticator
    {
        private readonly IDBRepository<User> dbRepository;
        private readonly IBCryptWrapper bCryptWrapper;

        public UserAuthenticator(IDBRepository<User> dbRepository, IBCryptWrapper bCryptWrapper)
        {
            this.dbRepository = dbRepository;
            this.bCryptWrapper = bCryptWrapper;
        }

        public bool Verify(string email, string unhashedPassword)
        {
            var user = dbRepository.GetByKey<String>("Email", email);
            return bCryptWrapper.Verify(unhashedPassword, user.HashedPassword);
        }
    }
}
