using Journal.Database.Entities.Application;
using Journal.Shared.Helpers;

namespace Journal.Shared.Tests.Helpers
{
    [TestFixture]
    public class JsonHelperTests
    {
        private string correctJson =
            "{\"Name\":\"Test Application 1\",\"Description\":\"\",\"IsLive\":false,\"Versions\":[],\"Id\":0,\"Guid\":\"00000000-0000-0000-0000-000000000000\"}";
        private Application correctApplication = new Application { Name = "Test Application 1", Guid = Guid.Empty, Description = "" };
        private string _name = "Test Application 1";
        private string _description = "";
        private Guid _guid = Guid.Empty;

        [Test]
        public void FromJsonOrNull_WhenJsonIsNull_ReturnsNull()
        {
            Type targetType = typeof(Application);
            bool saveTypes = false;

            var result = JsonHelper.FromJsonOrNull(null, targetType, saveTypes);

            Assert.IsNull(result);
        }

        [Test]
        public void FromJsonOrNull_WhenJsonIsEmpty_ReturnsNull()
        {
            Type targetType = typeof(Application);
            bool saveTypes = false;

            var result = JsonHelper.FromJsonOrNull("", targetType, saveTypes);

            Assert.IsNull(result);
        }

        [Test]
        public void FromJsonOrNull_WhenSaveTypesIsFalse_ReturnsCorrectApplication()
        {
            Type targetType = typeof(Application);
            bool saveTypes = false;

            var result = JsonHelper.FromJsonOrNull(correctJson, targetType, saveTypes) as Application;

            // Assert.AreEqual(correctApplication, result);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(_name));
            Assert.That(result!.Description, Is.EqualTo(_description));
            Assert.That(result!.Guid, Is.EqualTo(_guid));
        }

        [Test]
        public void FromJsonOrNull_WhenSaveTypesIsTrue_ReturnsCorrectApplication()
        {
            string json = CreateJsonWithTypes();
            Type targetType = typeof(TestClass);
            bool saveTypes = true;

            var result = JsonHelper.FromJsonOrNull(json, targetType, saveTypes) as TestClass;

            // Assert.AreEqual(correctApplication, result);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo("Test"));
            Assert.That(result!.Age, Is.EqualTo(10));
            var child = result!.Child as TestClass2;
            Assert.That(child, Is.Not.Null);
            Assert.That(child!.Name, Is.EqualTo("Child"));
            Assert.That(child!.Age, Is.EqualTo(5));
            Assert.That(child!.Description, Is.EqualTo("Test Description"));
        }

        [Test]
        public void FromJsonOrNull_IncorrectJson_ReturnsNull()
        {
            var json = "incorrect Json";
            Type targetType = typeof(Application);
            bool saveTypes = true;

            var result = JsonHelper.FromJsonOrNull(json, targetType, saveTypes);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ToJsonOrNull_NullSaveTypeFalse_ReturnsNull()
        {
            bool saveTypes = true;

            var result = JsonHelper.ToJsonOrNull(null, saveTypes);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ToJsonOrNull_NullSaveTypeTrue_ReturnsNull()
        {
            bool saveTypes = true;

            var result = JsonHelper.ToJsonOrNull(null, saveTypes);

            Assert.That(result, Is.Null);
        }

        [Test]
        public void ToJsonOrNull_NotNullSaveTypeFalse_ReturnsCorrectJson()
        {
            bool saveTypes = false;

            var result = JsonHelper.ToJsonOrNull(correctApplication, saveTypes);

            Assert.That(result, Is.EqualTo(correctJson));
        }

        [Test]
        public void ToJsonOrNull_NotNullSaveTypeTrue_ReturnsCorrectJson()
        {
            var expected = CreateJsonWithTypes();
            var target = CreateTestClass();
            bool saveTypes = true;

            var result = JsonHelper.ToJsonOrNull(target, saveTypes);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FromJson_CorrectObject_ReturnsCorrectJson()
        {
            var result = JsonHelper.FromJson(correctJson, typeof(Application)) as Application;

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Name, Is.EqualTo(_name));
            Assert.That(result!.Description, Is.EqualTo(_description));
            Assert.That(result!.Guid, Is.EqualTo(_guid));
        }

        [Test]
        public void ToJsonIndented_CorrectObject_ReturnsCorrectJson()
        {
            var result = JsonHelper.ToJsonIndented(correctApplication);

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void ToJson_CorrectObject_ReturnsCorrectJson()
        {
            var result = JsonHelper.ToJson(correctApplication);

            Assert.That(result, Is.EqualTo(correctJson));
        }

        [Test]
        public void ToJson_CorrectObjectWithTypes_ReturnsCorrectJson()
        {
            var expected = CreateJsonWithTypes();
            var target = CreateTestClass();

            var result = JsonHelper.ToJson(target, true);

            Assert.That(result, Is.EqualTo(expected));
        }

        private string CreateJsonWithTypes()
        {
            var json = "{" +
                       "\"$type\":\"Journal.Shared.Tests.Helpers.JsonHelperTests+TestClass, Journal.Shared.Tests\"," +
                       "\"Name\":\"Test\"," +
                       "\"Age\":10," +
                       "\"Child\":{" +
                           "\"$type\":\"Journal.Shared.Tests.Helpers.JsonHelperTests+TestClass2, Journal.Shared.Tests\"," +
                           "\"Description\":\"Test Description\"," +
                           "\"Name\":\"Child\"," +
                           "\"Age\":5," +
                           "\"Child\":null" +
                       "}" +
                    "}";
            return json;
        }

        private TestClass CreateTestClass()
        {
            return new TestClass
            {
                Name = "Test", 
                Age = 10, 
                Child = new TestClass2
                {
                    Name = "Child", 
                    Age = 5,
                    Description = "Test Description"
                }
            };
        }

        private class TestClass
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public TestClass? Child { get; set; }
        }

        private class TestClass2: TestClass
        {
            public string? Description { get; set; }
        }
    }
}
