using CryptoAlertCore.Models;
using LiteDB;

namespace CryptoAlertCore.DBRepository
{
    public class UserRepository : DBRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString) { }

        public User GetByEmail(string email)
        {
            using (LiteRepository db = new LiteRepository(_connectionString))
            {
                var user = db.Query<User>().Where(x => x.Email == email).First();
                return user;
            }
        }
    }
}
