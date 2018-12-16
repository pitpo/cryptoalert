using CryptoAlertCore.Models;

namespace CryptoAlertCore.DBRepository
{
    public interface IDBRepository<T> where T: DBModel
    {
        T GetById(int id);
        bool Insert(T obj);
        bool Update(T obj);
    }
}
