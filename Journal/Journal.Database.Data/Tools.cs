using Journal.Database.Data.Environment;

namespace Journal.Database.Data
{
    [TestFixture]
    [Category("Tools")]
    [Ignore("Manually run for populating seed data. Remember set user in memory DB to false.")]
    public class Tools
    {
        [Test]
        public void AddSeedData()
        {
            ServiceEnvironment.AddSeedData();
        }

        [Test]
        public void RemoveAllData()
        {
            ServiceEnvironment.RemoveAllData();
        }

        [Test]
        public void AddTestData()
        {
            ServiceEnvironment.AddTestData();
        }

        [Test]
        public void RemoveTestData()
        {
            ServiceEnvironment.RemoveTestData();
        }
    }
}
