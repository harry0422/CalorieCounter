namespace CalorieCounter.Common.Domain.Adapters
{
    public interface IEncryptionProvider
    {
        string Encrypt(string text);
        string Decript(string encryptedText);
    }
}