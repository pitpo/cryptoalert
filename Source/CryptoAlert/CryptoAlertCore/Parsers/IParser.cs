namespace CryptoAlertCore.Parsers
{
    public interface IParser<T>
    {
        T Parse(string textToParse);
    }
}
