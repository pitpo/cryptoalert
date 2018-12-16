using System;

namespace CryptoAlertCore.Models
{
    public class User : DBModel
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String HashedPassword { get; set; }
    }
}
