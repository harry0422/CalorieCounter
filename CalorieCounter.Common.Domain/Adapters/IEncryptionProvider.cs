namespace CalorieCounter.Common.Domain.Adapters
{
    public interface IEncryptionProvider
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string correctHash);
    }
}