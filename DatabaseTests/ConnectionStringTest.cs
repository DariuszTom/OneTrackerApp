using DbDataLibrary.Database;
using DbDataLibrary.Models.Entities;
using NUnit.Framework;

namespace DatabaseTests
{
    public class ConnectionStringTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DbExist()
        {
            var connChecker = new ConnectionChecker();
            Assert.IsFalse(connChecker.CouldConnect(), $"Could not connect to this connection string");
        }

        [Test]
        public void CouldConnect()
        {
            using (var testDBContext = new OneTrackerDBContext())
            {
                Assert.IsNotNull(testDBContext);
            }
        }
    }
}