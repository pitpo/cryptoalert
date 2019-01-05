using CryptoAlertCore.Models;

namespace CryptoAlertCore.DbRepository
{
    public interface IDbRepository<T> where T: DbModel
    {
        T GetById(int id);
        T GetByKey<U>(string key, U value);
        bool Insert(T userFavoriteCoins);
        bool Update(T obj);
    }
}
