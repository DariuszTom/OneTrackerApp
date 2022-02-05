using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace DatabaseTests
{
    internal class ServiceTests
    {
        [SetUp]
        public async Task ServiceStarts()
        {
            var host = new DatabaseService.OneTrackerDbServiceClient();
            int randomeNumber = new Random().Next();
            string expectedMsg = $"You entered: {randomeNumber}";
            Assert.Equals(await host.GetDataAsync(randomeNumber), expectedMsg);
        }
    }
}