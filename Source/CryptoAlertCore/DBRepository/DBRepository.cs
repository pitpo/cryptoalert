using CryptoAlertCore.Models;
using LiteDB;

namespace CryptoAlertCore.DBRepository
{
    public class DBRepository<T> : IDBRepository<T> where T: DBModel
    {
        protected readonly string _connectionString;

        public DBRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T GetById(int id)
        {
            return GetByKey<int>("_id", id);
        }

        public T GetByKey<U>(string key, U value)
        {
            using (LiteRepository db = new LiteRepository(_connectionString))
            {
                BsonValue bsonValue = new BsonValue(value);
                if (bsonValue == null) return null;
                return db.First<T>(Query.EQ(key, bsonValue));
            }
        }

        public bool Insert(T obj)
        {
            using (LiteRepository db = new LiteRepository(_connectionString))
            {
                var objectId = db.Insert<T>(obj);
                if (objectId == null) return false;
                return true;
            }
        }

        public bool Update(T obj)
        {
            using (LiteRepository db = new LiteRepository(_connectionString))
            {
                return db.Update<T>(obj);
            }
        }
    }
}
