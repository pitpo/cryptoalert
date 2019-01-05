using CryptoAlertCore.Models;
using LiteDB;
using System;

namespace CryptoAlertCore.DbRepository
{
    public class DbRepository<T> : IDbRepository<T> where T: DbModel
    {
        protected readonly string ConnectionString;

        public DbRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public T GetById(int id)
        {
            return GetByKey<int>("_id", id);
        }

        public T GetByKey<U>(string key, U value)
        {
            using (LiteRepository db = new LiteRepository(ConnectionString))
            {
                BsonValue bsonValue = new BsonValue(value);
                if (bsonValue == null) return null;
                try
                {
                    return db.First<T>(Query.EQ(key, bsonValue));
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
            
        }

        public virtual bool Insert(T userFavoriteCoins)
        {
            using (LiteRepository db = new LiteRepository(ConnectionString))
            {
                var objectId = db.Insert<T>(userFavoriteCoins);
                if (objectId == null) return false;
                return true;
            }
        }

        public bool Update(T obj)
        {
            using (LiteRepository db = new LiteRepository(ConnectionString))

            {
                return db.Update<T>(obj);
            }
        }
    }
}
