using CryptoAlertCore.Models;

namespace CryptoAlertCore.DBRepository
{
    public interface IUserRepository : IDBRepository<User>
    {   
        User GetByEmail(string value);
    }
}
