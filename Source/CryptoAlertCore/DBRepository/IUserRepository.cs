using System;
using System.Collections.Generic;
using System.Text;
using CryptoAlertCore.Models;
using LiteDB;

namespace CryptoAlertCore.DBRepository
{
    public interface IUserRepository : IDBRepository<User>
    {   
        User GetByEmail(string value);
    }
}
