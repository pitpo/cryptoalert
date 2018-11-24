namespace CryptoAlertCore.Parsers
{
    public interface IParser
    {
        T Parse<T>(string textToParse);
    }
}
