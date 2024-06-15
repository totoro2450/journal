using System.Globalization;
using Journal.Database.Base;

namespace Journal.Database.Tests.Base
{
    [TestFixture]
    public class EntityJsonBaseTests
    {
        private string _name { get; set; } = "testName";
        private EntityJsonBase _cut = new();

        [SetUp]
        public void Setup()
        {
            _cut = new() { Name = _name };
        }

        [Test]
        public void InitializedCorrectly()
        {
            Assert.That(_cut, Is.Not.Null);
            Assert.That(_cut, Is.InstanceOf<EntityJsonBase>());
            Assert.That(_cut.Name, Is.EqualTo(_name));
        }

        [Test]
        public void UpdateValue_StringNotEncrypted_UpdatedCorrectly()
        {
            var value = "test";
            var type = typeof(string).AssemblyQualifiedName;
            
            _cut.Value = value;

            Assert.That(_cut.Json, Is.EqualTo("\"test\""));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_IntegerNotEncrypted_UpdatedCorrectly()
        {
            var value = 42;
            var type = typeof(int).AssemblyQualifiedName;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.EqualTo("42"));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_DoubleNotEncrypted_UpdatedCorrectly()
        {
            var value = 42.3;
            var type = typeof(double).AssemblyQualifiedName;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.EqualTo("42.3"));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_BooleanNotEncrypted_UpdatedCorrectly()
        {
            var value = true;
            var type = typeof(bool).AssemblyQualifiedName;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.EqualTo("true"));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_NullNotEncrypted_UpdatedCorrectly()
        {
            var type = typeof(Object).AssemblyQualifiedName;

            _cut.Value = null!;

            Assert.That(_cut.Json, Is.EqualTo(null));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(null));
        }

        [Test]
        public void UpdateValue_StringEncrypted_UpdatedCorrectly()
        {
            var value = "test";
            var type = typeof(string).AssemblyQualifiedName;
            _cut.IsEncrypted = true;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.Not.Null);
            Assert.That(_cut.Json.Length, Is.GreaterThan(value.ToString(CultureInfo.InvariantCulture).Length));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_IntegerEncrypted_UpdatedCorrectly()
        {
            var value = 42;
            var type = typeof(int).AssemblyQualifiedName;
            _cut.IsEncrypted = true;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.Not.Null);
            Assert.That(_cut.Json.Length, Is.GreaterThan(value.ToString(CultureInfo.InvariantCulture).Length));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_DoubleEncrypted_UpdatedCorrectly()
        {
            var value = 42.3;
            var type = typeof(double).AssemblyQualifiedName;
            _cut.IsEncrypted = true;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.Not.Null);
            Assert.That(_cut.Json.Length, Is.GreaterThan(value.ToString(CultureInfo.InvariantCulture).Length));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_BooleanEncrypted_UpdatedCorrectly()
        {
            var value = true;
            var type = typeof(bool).AssemblyQualifiedName;
            _cut.IsEncrypted = true;

            _cut.Value = value;

            Assert.That(_cut.Json, Is.Not.Null);
            Assert.That(_cut.Json.Length, Is.GreaterThan(value.ToString(CultureInfo.InvariantCulture).Length));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(value));
        }

        [Test]
        public void UpdateValue_NullEncrypted_UpdatedCorrectly()
        {
            var type = typeof(Object).AssemblyQualifiedName;
            _cut.IsEncrypted = true;

            _cut.Value = null!;

            Assert.That(_cut.Json, Is.EqualTo(null));
            Assert.That(_cut.Type, Is.EqualTo(type));
            Assert.That(_cut.Value, Is.EqualTo(null));
        }
    }
}
