using Journal.Database.Entities;
using Journal.Tests.TestData.Attributes;

namespace Journal.Tests.TestData.Applications
{
    [TestPoco(TestLifeTime.EntireRun, TestDataTypeOrder.Application)]
    public class TestApplication: Application
    {
        public TestApplication()
        {
            Guid = Guid.NewGuid();
            Description = "Test Application Description";
            IsLive = true;
            Name = "Test Application";
        }
    }

    [TestPoco(TestLifeTime.EntireRun, TestDataTypeOrder.ApplicationVersion)]
    public class TestApplicationVersion : ApplicationVersion
    {
        public TestApplicationVersion()
        {
            Guid = Guid.NewGuid();
            ApplicationId = TestData.GetPoco<TestApplication>().Id;
        }
    }

    [TestPoco(TestLifeTime.SingleTest)]
    public class TestApplication2 : Application
    {
        public TestApplication2()
        {
            Guid = Guid.NewGuid();
            Description = "Test Application 2 Description";
            IsLive = true;
            Name = "Test Application 2";
        }
    }
}
