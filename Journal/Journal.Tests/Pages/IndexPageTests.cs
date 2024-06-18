using Journal.Database.Data.Environment;
using Journal.Pages;
using Journal.Tests.Environment;

namespace Journal.Tests.Pages
{
    [TestFixture]
    public class IndexPageTests
    {
        private JournalEnvironmentSuccess _environmentSuccess = new JournalEnvironmentSuccess();
        private JournalEnvironmentError _environmentError = new JournalEnvironmentError();
        private IndexModel _cut;

        [SetUp]
        public void Setup()
        {
            _cut = _environmentSuccess.GetService<IndexModel>();
        }

        [Test]
        public void JournalInitializedCorrectly()
        {
            Assert.That(_cut, Is.Not.Null);
        }

        [Test]
        public void ApplicationCount()
        {
            Assert.That(_cut.GetApplicationCount(), Is.EqualTo(1));
            Assert.That(ServiceEnvironment.DatabaseContext.ApplicationVersions.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ErrorEnv()
        {
            Assert.Throws<InvalidOperationException>(() => _environmentError.GetService<IndexModel>(),
                "No service for type 'Journal.Pages.IndexModel' has been registered.");
        }
    }
}
