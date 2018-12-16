using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace CryptoAlertCore.Models
{
    public class DBModel
    {
        [BsonId]
        public int Id { get; set; }
    }
}
