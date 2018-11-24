using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CryptoAlertCore.Parsers
{
    public class JsonParser<T> : IParser<T> 
    {
        public T Parse(string textToParse)
        {
           return JsonConvert.DeserializeObject<T>(textToParse);
        }
    }
}
