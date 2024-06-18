using Journal.Database.Data.Environment;

namespace Journal.Tests
{
    [SetUpFixture]
    public class TestRun
    {
        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            ServiceEnvironment.AddTestData();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ServiceEnvironment.RemoveTestData();
        }
    }
}
