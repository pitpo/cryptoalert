using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace CryptoAlertCore.Models
{
    public class User : DBModel
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
