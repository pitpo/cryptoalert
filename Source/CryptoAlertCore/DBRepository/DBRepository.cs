using System;
using System.Collections.Generic;
using System.Text;
using CryptoAlertCore.Models;
using LiteDB;

namespace CryptoAlertCore.DBRepository
{
    public abstract class DBRepository<T> : IDBRepository<T> where T: DBModel
    {
        protected string _connectionString;

        public DBRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public T GetById(int id)
        {
            using (LiteRepository db = new LiteRepository(_connectionString))
            {
                return db.Query<T>().Where(x => x.Id == id).First();
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
