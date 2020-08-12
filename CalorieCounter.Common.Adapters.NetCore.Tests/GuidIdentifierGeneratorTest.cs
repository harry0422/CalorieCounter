using NUnit.Framework;

namespace CalorieCounter.Common.Adapters.NetCore.Tests
{
    [TestFixture]
    public class GuidIdentifierGeneratorTest
    {
        [Test]
        public void GuidIdentifierGenerator_GenerateGuidString()
        {
            // Arrange
            GuidIdentifierGenerator identifierGenerator = new GuidIdentifierGenerator();

            // Act
            string id = identifierGenerator.GetIdentifier();

            // Assert
            Assert.AreEqual(36, id.Length);
            Assert.AreEqual(4, id.Length - id.Replace("-", "").Length);
        }
    }
}