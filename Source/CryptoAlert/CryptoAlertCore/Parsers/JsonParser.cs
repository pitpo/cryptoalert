using Newtonsoft.Json;

namespace CryptoAlertCore.Parsers
{
    public class JsonParser : IParser
    {
        public T Parse<T>(string textToParse)
        {
           return JsonConvert.DeserializeObject<T>(textToParse);
        }
    }
}
