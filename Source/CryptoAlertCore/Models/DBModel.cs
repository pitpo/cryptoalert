using LiteDB;

namespace CryptoAlertCore.Models
{
    public class DbModel
    {
        [BsonId]
        public int Id { get; set; }
    }
}
