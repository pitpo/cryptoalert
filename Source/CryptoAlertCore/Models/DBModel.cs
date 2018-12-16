using LiteDB;

namespace CryptoAlertCore.Models
{
    public class DBModel
    {
        [BsonId]
        public int Id { get; set; }
    }
}
