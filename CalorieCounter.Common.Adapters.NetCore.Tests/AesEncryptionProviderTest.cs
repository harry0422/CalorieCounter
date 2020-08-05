using NUnit.Framework;

namespace CalorieCounter.Common.Adapters.NetCore.Tests
{
    [TestFixture]
    public class AesEncryptionProviderTest
    {
        [Test]
        public void Encrypt_ReturnsEncryptedText()
        {
            //Arrange
            PBKDF2EncryptionProvider encryptionProvider = new PBKDF2EncryptionProvider();
            string password = "Harry Potter";

            //Act
            string hashedPassword = encryptionProvider.HashPassword(password);
            bool isValidHash = encryptionProvider.ValidatePassword(password, hashedPassword);

            //Assert
            Assert.AreEqual(true, isValidHash);
        }

        [Test]
        public void ValidatePassword_ValidateCorrectPassword()
        {
            //Arrange
            PBKDF2EncryptionProvider encryptionProvider = new PBKDF2EncryptionProvider();
            string password = "Harry Potter";
            string correctHash = "1000:hRV8Hi+rH8zlBfOSUxx+7/xCXzb9h6KZ:iVP+ngW0U8Z9xNTNFYMfBN4UCKs=";

            //Act
            bool isCorrectPassword = encryptionProvider.ValidatePassword(password, correctHash);

            //Assert
            Assert.AreEqual(true, isCorrectPassword);
        }
    }
}