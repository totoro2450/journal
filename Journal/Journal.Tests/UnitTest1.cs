using Journal.Tests.Environment;

namespace Journal.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(EnvironmentBase.BirthDay, Is.EqualTo(DateTime.MaxValue));
        }

        [Test]
        public void JournalInitializedCorrectly()
        {
            var model = TestEnvironment.Success.GetService<Pages.IndexModel>();

            Assert.That(model, Is.Not.Null);
        }

        [Test]
        public void ApplicationCount()
        {
            var model = TestEnvironment.Success.GetService<Pages.IndexModel>();

            Assert.That(model.GetApplicationCount(), Is.EqualTo(1));
            Assert.That(TestEnvironment.DataBase.ApplicationVersions.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ErrorEnv()
        {
            Assert.Throws<InvalidOperationException>(() => TestEnvironment.Error.GetService<Pages.IndexModel>(), 
                "No service for type 'Journal.Pages.IndexModel' has been registered.");
        }
    }
}