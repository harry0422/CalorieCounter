using NHibernate;
using NUnit.Framework;

namespace CalorieCounter.Common.NHibernateConfiguration.Tests
{
    [TestFixture]
    public class NhSessionFactoryTest
    {
        [Test]
        public void Create_CreatesSessionFactory()
        {
            //Arrange
            string connectionString = "Server=caloriecounterdb.ctqkf7zbkikh.us-east-2.rds.amazonaws.com;Port=5432;Database=postgres;User Id=postgres;Password=Honduras2020;";

            //Act
            ISessionFactory sessionFactory = NhSessionFactory.Create(connectionString);

            //Assert
            Assert.IsNotNull(sessionFactory);
        }
    }
}