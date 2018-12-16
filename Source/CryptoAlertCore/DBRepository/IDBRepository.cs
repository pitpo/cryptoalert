using CryptoAlertCore.Models;

namespace CryptoAlertCore.DBRepository
{
    public interface IDBRepository<T> where T: DBModel
    {
        T GetById(int id);
        T GetByKey<U>(string key, U value);
        bool Insert(T obj);
        bool Update(T obj);
    }
}
