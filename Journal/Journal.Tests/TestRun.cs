using Journal.Tests.Environment;

namespace Journal.Tests
{
    [SetUpFixture]
    public class TestRun
    {
        [OneTimeSetUp]
        public void OnTimeSetUp()
        {
            TestEnvironment.CreateTestData();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            TestEnvironment.RemoveTestData();
        }
    }
}
