using DatabaseAccessLayer;

namespace Unittestingjobportals
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void UserTable_CompanyTablesInitialized_Success()
        {
            // Arrange
            var user = new UserTable();

            // Act

            // Assert
            Assert.IsNotNull(user.CompanyTables);
            Assert.IsInstanceOf<HashSet<CompanyTable>>(user.CompanyTables);
        }

    }
}