using CryptoAlertCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoAlertCore.DBRepository
{
    public interface IDBRepository<T> where T: DBModel
    {
        T GetById(int id);
        bool Insert(T obj);
        bool Update(T obj);
    }
}
